import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { backendUrl } from '../App';
import { toast } from 'react-toastify';
import { getImageURL } from '../utils/image-util';

function List({ token }) {

    const [list, setList] = useState([]);

    const fetchList = async () => {
        try {
            const response = await axios.get(backendUrl + '/api/Products/GetAllProductWithName')
            console.log(response.data);
            if (response.data) {
                setList(response.data)

            }
            else {
                toast.error(response.data.message)
            }
        } catch (error) {
            console.log(error)
            toast.error(error.message);
        }
    }
    const removeProduct = async (id) => {

        try {
            const response = await axios.delete(`${backendUrl}/api/Products/DeleteProduct`, {
                headers: {
                    Authorization: `Bearer ${token}`
                },
                params: { id } // Query parametresine ID ekleniyor
            });

            if (response.status === 200) {
                toast.success('Ürün başarıyla silindi:', response.data);
                await fetchList();
            } else {
                toast.error('Silme işlemi başarısız:', response.data);
            }
        } catch (error) {
            console.log(error)
            toast.error(error.message)
        }
    }
    useEffect(() => {
        fetchList()
    }, [])
    return (
        <>
            <p className='mb-2'>All Product List</p>
            <div className='felex flex-col gap-2'>

                {/* ----------List Table Title ---------- */}
                <div className='hidden md:grid grid-cols-[1fr_3fr_1fr_1fr_1fr_2fr_1fr_1fr] gap-5 items-center py-1 px2 border bg-gray-100 text-sm '>
                    <b>Image</b>
                    <b>Name</b>
                    <b>Brand</b>
                    <b>Category</b>
                    <b>TopCategory</b>
                    <b>Purchase Price</b>
                    <b>Selling Price</b>
                    <b className='text-center'>Action</b>

                </div>
                {/* ----------- Product List -------------- */}
                {
                    list.map((item, index) => (
                        <div className='grid grid-cols-[1fr_3fr_1fr] md:grid-cols-[1fr_3fr_1fr_1fr_1fr_2fr_1fr_1fr] items-center gap-2 py-1 px-2 border text-sm' key={index}>
                            <img className='w-28' src={getImageURL(item.productimage)} />
                            <p>{item.productname}</p>
                            <p>{item.productbrandname}</p>
                            <p>{item.categoryname}</p>
                            <p>{item.topcategoryname}</p>
                            <p>{item.productpriceB}</p>
                            <p>{item.productpriceS}</p>
                            <p onClick={() => removeProduct(item.productid)} className='text-right md:text-center cursor-pointer text-lg'>X</p>
                        </div>
                    ))

                }
            </div>
        </>
    )
}

export default List