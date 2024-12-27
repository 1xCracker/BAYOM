import React, { useState } from 'react'
import { assets } from '../assets/assets'
import axios from 'axios'
import { backendUrl } from '../App';


function Add() {

    const [image1, setImage1] = useState(false)
    const [name, setName] = useState("");
    const [description, setDescription] = useState('');
    const [price, setPrice] = useState("");
    const [category, setCategory] = useState("");
    const [topCategory, setTopCategory] = useState("");
    const [productBrand, setProductBrand] = useState("")

    const onSubmitHandler = async (e) => {
        e.preventDefault(); // form submit edildiğinde sayfanın yeniden yüklenmesini önler
        try {
            const formData = new FormData()
            formData.append("productname", name)
            formData.append("productdescription", description)
            formData.append("productprices", price)
            formData.append("categoryid", category)
            formData.append("topcategoryid", topCategory)
            formData.append("productbrand", productBrand)
            formData.append("image", image1)

            for (let [key, value] of formData.entries()) { console.log(`${key}: ${value}`); }
            // const response = await axios.post(backendUrl +"api/product/add",formData)

        } catch (error) {
            console.log(error)
        }
    }

    return (
        <form onSubmit={onSubmitHandler} className='flex flex-col w-full items-start gap-3'>
            <div>
                <p className='mb-2'>Upload Image</p>
                <div className='flex gap-2'>
                    <label htmlFor='image1'>
                        <img className='w-20' src={!image1 ? assets.upload_area : URL.createObjectURL(image1)} alt='' />
                        <input onChange={(e) => setImage1(e.target.files[0])} type='file' id="image1" hidden />
                    </label>
                </div>
            </div>
            <div className='w-full'>
                <p className='mb-2'>Product Name</p>
                <input onChange={(e) => setName(e.target.value)} value={name} className='w-full max-w-[500px] px-3 py-2' type="text" placeholder='Type here' required />
            </div>
            <div className='w-full'>
                <p className='mb-2'>Product Description</p>
                <textarea onChange={(e) => setDescription(e.target.value)} value={description} className='w-full max-w-[500px] px-3 py-2' type="text" placeholder='Write content here' required />
            </div>
            <div className='w-full'>
                <p className='mb-2'>Product Price</p>
                <input onChange={(e) => setPrice(e.target.value)} value={price} className='w-full max-w-[500px] px-3 py-2' type="number" placeholder='Type here' required />
            </div>
            <div className='flex flex-col sm:flex-row gap-2 w-full sm:gap-8'>
                <div>
                    <p className='mb-2'>Product Brand</p>
                    <select onChange={(e) => setProductBrand(e.target.value)} className='w-full px-3 py-2'>
                        <option value="1">Brand</option>
                    </select>
                </div>
                <div>
                    <p className='mb-2'>Product Top Category </p>
                    <select onChange={(e) => setTopCategory(e.target.value)} className='w-full px-3 py-2'>
                        <option value="1">Top</option>
                    </select>
                </div>
                <div>
                    <p className='mb-2'>Product Category</p>
                    <select onChange={(e) => setCategory(e.target.value)} className='w-full px-3 py-2'>
                        <option>Category</option>
                    </select>
                </div>
               
            </div>
            <button type='submit' className='w-28 py-3 mt-4  bg-black text-white'>ADD</button>
        </form>
    )
}

export default Add