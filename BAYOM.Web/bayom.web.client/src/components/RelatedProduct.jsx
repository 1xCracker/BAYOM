import React, { useContext, useEffect, useState } from 'react'
import { ShopContext } from '../context/ShopContext'
import Title from './Title';
import ProductItem from './ProductItem';

function RelatedProduct({ category, subCategory }) {

    const { product } = useContext(ShopContext);
    const [related, setRelated] = useState([]);

    useEffect(() => {

        if (product.length > 0) {

            let productsCopy = product.slice();
            productsCopy = productsCopy.filter((item) => category === item.categoryid);
            productsCopy = productsCopy.filter((item) => subCategory === item.topcategoryid);
            setRelated(productsCopy.slice(0, 5))

        }

    }, [product])
    return (
        <div className='my-24'>
            <div className='text-center text-3xl py-2'>
                <Title text1={'RELATED'} text2={"PRODUCTS"} />
            </div>
            <div className='grid grid-cols-2 sm:grid-cols-4 lg:grid-cols-5 gap-4 gap-y-6'>
                {
                    related.map((item, index) => (
                        <ProductItem key={index} id={item.productid} name={item.productname} price={item.productpriceS} image={item.productimage} />
                    ))
                }

            </div>
        </div>
    )
}

export default RelatedProduct