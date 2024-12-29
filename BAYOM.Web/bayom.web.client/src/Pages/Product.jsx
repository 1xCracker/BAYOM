import React, { useContext, useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { ShopContext } from '../context/ShopContext';
import { assets } from '../assets/assets';
import RelatedProduct from '../components/RelatedProduct';
import { getImageURL } from '../utils/image-util';


function Product() {
    const { productid } = useParams();
    const { product, currency, addToCart } = useContext(ShopContext);
    const [productData, setProducData] = useState(false);
    const [image, setImage] = useState('')
    const [size, setSize] = useState('')

    const fetchProductData = async () => {
        product.map((item) => {

            if (item.productid == productid) {
                setProducData(item)
                setImage(getImageURL(item.productimage))
                return null;
            }


        })
    }
    useEffect(() => {
        fetchProductData();
    }, [productid, product])
    return productData ? (
        <div className='border-t-2 pt-10 transition-opacity ease-in duration-500 opacity-100'>
            {/*-------- Product Data -----------*/}
            <div className='flex gap-12 sm:gap-12 flex-col sm:flex-row'>
                {/*------------ Product Image------------*/}
                <div className='flex-1 flex flex-col-reverse gap-3 sm:flex-row'>
                    <div className='flex sm:flex-col overflow-x-auto sm:overflow-y-scroll justify-between sm:justify-normal sm:w-[18.7%] w-full'>
                        {

                            <img onClick={() => setImage(getImageURL(productData.productimage))} src={getImageURL(productData.productimage)} key={productid} className='w-[24%] sm:w-full sm:mb-3 flex-shrink-0 cursor-pointer' />

                        }
                    </div>
                    <div className='w-full sm:w-[90%]'>
                        <img className='w-full h-auto ' src={image} alt={productData.productname} />
                    </div>

                </div>

                {/* ----------------------product Info ------------------- */}
                <div className='felx-1'>
                    <h1 className='font-medium text-2xl mt-2'>{productData.productname}</h1>
                    <div className='flex items-center gap-1 mt-2'>
                        <img src={assets.star_icon} className='w-3 ' />
                        <img src={assets.star_icon} className='w-3 ' />
                        <img src={assets.star_icon} className='w-3 ' />
                        <img src={assets.star_icon} className='w-3 ' />
                        <img src={assets.star_dull_icon} className='w-3 5' />
                        <p className='pl-2'>(122)</p>
                    </div>
                    <p className='mt-5 text-3xl font-medium'>{currency}{productData.productpriceS}</p>
                    <p className='mt-5 text-gray-500 md:w/4/5'>{productData.productdescription}</p>
                    {/* <div className='flex flex-col gap-4 my-8'>
                        <p>Select Size</p>
                        <div className='flex gap-2'>
                            {productData.sizes.map((item, index) => (
                                <button onClick={() => setSize(item)} className={`border py-2 px-4 bg-gray-100 ${item === size ? 'border-orange-500' : ''}`} key={index}>{item}</button>
                            ))}
                        </div>
                    </div> */}
                    <button onClick={() => addToCart(productData.productid)} className='bg-black text-white mt-7 px-8 py-3 text-sm active:bg-gray-700'>ADD TO CART</button>
                    <hr className='mt-8 sm:w-4/5' />
                    <div className='text-sm text-gray-500 mt-5 flex flex-col gap-1'>
                        <p>100% Orginal product.</p>
                        <p>Cash on delivery is available on this product.</p>
                        <p>Easy return and exchange policy within 7 days.</p>
                    </div>
                </div>
            </div>
            {/* -------deccription & reviev section ------- */}
            <div className='mt-20'>
                <div className='flex'>
                    <b className='border px-5 py-3 text-sm'>Description</b>
                    <p className='border px-5 py-3 text-sm'>Reviews (31)</p>
                </div>
                <div className='flex flex-col gap-4 border px-6 py-6 text-sm text-gray-500'>
                    <p>An e-commerce website is an online platform that facilitates the buying and selling of products or services over the internet. It serves as a virtual marketplace where businesses and individuals can showcase their products, interact with customers, and conduct transactions without the need for a physical presence. E-commerce websites have gained immense popularity due to their convenience, accessibility, and the global reach they offer.</p>
                    <p>E-commerce websites typically display products or services along with detailed descriptions, images, prices, and any available variations (e.g., sizes, colors). Each product usually has its own dedicated page with relevant information.</p>
                </div>
            </div>
            {/* --------display related product---------- */}
            <RelatedProduct category={productData.categoryid} subCategory={productData.topcategoryid} />
        </div>
    ) : <div className='opacity-0'></div>
}

export default Product