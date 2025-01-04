import React, { useEffect, useState } from 'react'
import { assets } from '../assets/assets';
import { backendUrl } from '../App';
import { toast } from 'react-toastify';
import axios from 'axios';

function Orders() {

    const [orders, setOrders] = useState([]);

    const fetchList = async () => {
        try {
            const response = await axios.get(backendUrl + '/api/Orders/Orders')
            console.log(response.data);
            if (response.data) {
                setOrders(response.data)

            }
            else {
                toast.error(response.data.message)
            }
        } catch (error) {
            console.log(error)
            toast.error(error.message);
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
                <div className='hidden md:grid grid-cols-[1fr_1fr_1fr_3fr_5fr_1fr_1fr_1fr] gap-5 items-center py-1 px2 border bg-gray-100 text-sm '>
                    <b>Image</b>
                    <b>Name</b>
                    <b>Date</b>
                    <b>Address</b>
                    <b>Product</b>
                    <b>Total</b>
                    <b>Status</b>
                    <b className='text-center'>Action</b>

                </div>
                {/* ----------- Product List -------------- */}
                {
                    orders.map((item, index) => (
                        <div className='grid grid-cols-[1fr_1fr_1fr] md:grid-cols-[1fr_1fr_1fr_3fr_5fr_1fr_1fr_1fr] items-center gap-2 py-1 px-2 border text-sm' key={index}>
                            <img className='w-5' src={assets.order_icon} />
                            <p>{item.fullName}</p>
                            <p>{item.date}</p>
                            <p>{item.address}</p>
                            <select>
                                {item.products.map((product, index) => (
                                    <option key={index}>
                                        {`Product Name: ${product.productName}, Quantity: ${product.quantity}, Price: ${product.price}, Total: ${product.total}`}
                                    </option>
                                ))}

                            </select>

                            <p>{item.total}</p>
                            <p>{item.status}</p>
                            <p className='text-right md:text-center cursor-pointer text-lg'>Beklemede</p>
                        </div>
                    ))

                }
            </div>
        </>
    )
}

export default Orders