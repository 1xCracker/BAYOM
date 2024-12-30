import { useContext, useState } from 'react'
import { assets } from '../assets/assets'
import axios from 'axios'
import { backendUrl } from '../App';
import { AdminContext } from '../context/AdminContext';


function Add() {

    const [image1, setImage1] = useState(false)
    const [name, setName] = useState("");
    const [description, setDescription] = useState('');
    const [priceB, setPriceB] = useState();
    const [priceS, setPriceS] = useState();
    const [category, setCategory] = useState();
    const [topCategory, setTopCategory] = useState();
    const [productBrand, setProductBrand] = useState()
    const { categories, topCategories, brands } = useContext(AdminContext)
    const [imageName, setImageName] = useState("");
    const handleImageChange = (e) => {
        const file = e.target.files[0];
        if (file) {
            setImage1(file);
            setImageName(file.name);  // Dosyanın adını al
        }
    };

    const onSubmitHandler = async (e) => {
        e.preventDefault();

        try {
            const formData = new FormData()
            formData.append("productname", name)
            formData.append("productdescription", description)
            formData.append("productpriceB", parseFloat(priceB))
            formData.append("productpriceS", parseFloat(priceS))
            formData.append("categoryid", parseInt(category))
            formData.append("topcategoryid", parseInt(topCategory))
            formData.append("productbrandid", parseInt(productBrand))
            formData.append("productimage", imageName)
            console.log(formData)
            const response = await axios.post(backendUrl + "/api/products/addProduct", formData)
            console.log(response)
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
                        <input onChange={handleImageChange} type='file' id="image1" hidden />
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
                <p className='mb-2'>Purchase Price</p>
                <input onChange={(e) => setPriceB(e.target.value)} value={priceB} className='w-full max-w-[500px] px-3 py-2' type="number" placeholder='Type here' required />
            </div>
            <div className='w-full'>
                <p className='mb-2'>Selling Price</p>
                <input onChange={(e) => setPriceS(e.target.value)} value={priceS} className='w-full max-w-[500px] px-3 py-2' type="number" placeholder='Type here' required />
            </div>
            <div className='flex flex-col sm:flex-row gap-2 w-full sm:gap-8'>
                <div>
                    <p className='mb-2'>Product Brand</p>
                    <select onChange={(e) => setProductBrand(e.target.value)} className='w-full px-3 py-2'>
                        <option value="">Select</option>
                        {
                            brands.map((item, index) => (
                                <option key={index} value={item.productbrandid}>{item.productbrandname}</option>
                            ))
                        }

                    </select>
                </div>
                <div>
                    <p className='mb-2'>Product Top Category </p>
                    <select onChange={(e) => setTopCategory(parseInt(e.target.value))} className='w-full px-3 py-2'>
                        <option value="">Select</option>
                        {
                            topCategories.map((item, index) => (
                                <option key={index} value={parseInt(item.topcategoryid)}>{item.topcategoryname}</option>
                            ))
                        }
                    </select>
                </div>
                <div>
                    <p className='mb-2'>Product Category</p>
                    <select onChange={(e) => setCategory(parseInt(e.target.value))} className='w-full px-3 py-2'>
                        <option value="">Select</option>
                        {
                            categories.map((item, index) => (
                                <option key={index} value={parseInt(item.categoryid)}>{item.categoryname}</option>
                            ))
                        }
                    </select>
                </div>

            </div>
            <button type='submit' className='w-28 py-3 mt-4  bg-black text-white'>ADD</button>
        </form>
    )
}

export default Add