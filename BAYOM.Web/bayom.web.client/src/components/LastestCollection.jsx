
import { useContext, useEffect, useState } from 'react';
import React from 'react';
import { ShopContext } from '../context/ShopContext';
import Title from './Title';
import ProductItem from './ProductItem';


function LastestCollection() {
    const { products } = useContext(ShopContext);

    const [lastestProduct, setLastestProduct] = useState([]);
    useEffect(() => {
        setLastestProduct(products.slice(0, 10));
    }, []);
    return (
        <div className='my-10'>
            <div className='text-center py-8 text-3xl'>
                <Title text1={'LASTEST '} text2={'COLLECTION'} />
                <p className='w-3/4 m-auto text-xs sm:text-sm md:text-base text-gray-600'>
                    BayoTech CLUB'a üye olun ve özel avantajlardan yararlanmaya başlayın.
                </p>
            </div>
            {/* Rendering Products */}
            <div className='grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-4 gap-y-6 '>
                {
                    lastestProduct.flatMap((item, index) => (
                        <ProductItem key={index} id={item.id} image={item.image} name={item.name} price={item.price} />
                    ))
                }
            </div>
        </div>
    )
}

export default LastestCollection