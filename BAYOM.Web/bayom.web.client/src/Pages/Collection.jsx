import React, { useContext, useEffect, useState } from 'react'
import { ShopContext } from '../context/ShopContext'
import { assets } from '../assets/assets'
import Title from '../components/Title'
import ProductItem from '../components/ProductItem'
import axios from 'axios';
import { backendUrl } from '../App'
function Collection() {
    const { product, search, showSearch, topCategory, productBrand } = useContext(ShopContext)
    const [showFilter, setShowFilter] = useState(false)
    const [filterProducts, setFilterProducts] = useState([])
    const [categoryFilter, setCategoryFilter] = useState([]);
    const [topCategoryFilter, setTopCategoryFilter] = useState([]);
    const [sortType, setSortType] = useState('relavent')
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [categoryData, setCategoryData] = useState([]);

    const toggleTopCategory = async (e) => {
        const value = parseInt(e.target.value); // Sayıya çeviriyoruz
        if (topCategoryFilter.includes(value)) {
            setTopCategoryFilter(prev => prev.filter(item => item !== value));
            setSelectedCategory(null);
        } else {
            setTopCategoryFilter([]);
            setSelectedCategory(value);
            try {

                const response = await axios.post(`${backendUrl}/api/CategoryBrand/TopCategory`, null, {
                    params: {
                        id: value  // gönderilecek veri
                    },
                    headers: { 'Content-Type': 'application/json' },
                });

                // Eğer başarılı bir cevap alırsanız, ilgili kategorileri işleyin
                console.log('API Response:', response.data);

                // Burada, API'den dönen kategorileri alıp güncelleyebilirsiniz
                // Örneğin, kategori bilgilerini bir state'e atabilirsiniz
                setCategoryData(response.data);
                setTopCategoryFilter(prev => [...prev, value]);  // 'setFilteredCategories' istediğiniz bir state olabilir
            } catch (error) {
                console.error('API request failed:', error);
            }
        }
    }

    const toggleCategory = (e) => {
        const value = parseInt(e.target.value);
        if (categoryFilter.includes(value)) {
            setCategoryFilter(prev => prev.filter(item => item !== value))
        }
        else {
            setCategoryFilter(prev => [...prev, value])
        }
    }

    const applyFilter = () => {
        let productsCopy = product.slice();

        if (showSearch && search) {
            productsCopy = productsCopy.filter(item => item.productname.toLowerCase().includes(search.toLowerCase()))
        }

        if (topCategoryFilter.length > 0) {

            productsCopy = productsCopy.filter(item => topCategoryFilter.includes(item.topcategoryid))

        }

        if (categoryFilter.length > 0) {
            productsCopy = productsCopy.filter(item => categoryFilter.includes(item.categoryid))
        }

        setFilterProducts(productsCopy)

    }

    const sortProduct = () => {
        let fpCopy = filterProducts.slice();
        switch (sortType) {
            case 'low-hight':
                setFilterProducts(fpCopy.sort((a, b) => (a.productpriceS - b.productpriceS)))
                break;
            case 'hight-low':
                setFilterProducts(fpCopy.sort((a, b) => (b.productpriceS - a.productpriceS)))
                break;
            default:
                applyFilter();
                break;
        }
    }

    useEffect(() => {
        applyFilter();
    }, [categoryFilter, topCategoryFilter, search, showFilter, product, topCategory, productBrand])

    useEffect(() => {
        sortProduct();
    }, [sortType])

    return (
        <div className='flex flex-col sm:flex-row gap-1 sm:gap-10 pt-10 border-t'>
            {/* Filter Options */}
            <div className='min-w-60'>
                <p onClick={() => setShowFilter(!showFilter)} className='my-2 text-xl flex items-center cursor-pointer gap-2 '>FILTERS
                    <img className={`h-3 sm:hidden ${showFilter ? 'rotate-90' : ''}`} src={assets.dropdown_icon} alt='' />
                </p>

                {/* Category  Filter */}
                <div className={`border border-gray-300 pl-5 py-3 mt-6 ${showFilter ? '' : 'hidden'} sm:block`}>
                    <p className='mb-3 text-sm font-medium'>CATEGORIES</p>
                    <div className='flex flex-col gap-2 text-sm font-light text-gray-700'>
                        {
                            topCategory.map((item, index) => {
                                return (
                                    <div key={index} className='flex gap-2' >
                                        <input id={`top-category-${item.topcategoryid}`} className='w-3' type='checkbox' value={item.topcategoryid} onChange={toggleTopCategory} checked={selectedCategory === item.topcategoryid} />
                                        <label htmlFor={`top-category-${item.topcategoryid}`}>{item.topcategoryname}</label>
                                    </div>
                                );
                            })
                        }
                    </div>
                </div>
                <p className='my-2 text-xl flex items-center cursor-pointer gap-2 '>TYPE</p>
                {/*  sub category filter */}
                <div className={`border border-gray-300 pl-5 py-3 my-5 ${showFilter ? '' : 'hidden'} sm:block`}>
                    <p className='mb-3 text-sm font-medium'>CATEGORIES</p>
                    <div className='flex flex-col gap-2 text-sm font-light text-gray-700'>

                        {categoryData.map((category, index) => (
                            <p key={index} className='flex gap-2'>
                                <input
                                    className='w-3'
                                    type='checkbox'
                                    value={category.categoryid}
                                    onChange={toggleCategory}
                                />
                                {category.categoryname}
                            </p>
                        ))}

                    </div>
                </div>
                {/* */}
            </div>
            {/* Right Side */}
            <div className='flex-1'>
                <div className='flex justify-between text-base sm:text-2xl mb-4'>
                    <Title text1={'ALL'} text2={'COLLECTIONS'} />
                    {/* product sort */}
                    <select onChange={(e) => setSortType(e.target.value)} className='border-2 border-gray-300 textsm px-2'>
                        <option value="relavent">Sort by: Relavent</option>
                        <option value="low-hight">Sort by: Low to High</option>
                        <option value="hight-low">Sort by: High to Low</option>
                    </select>
                </div>
                {/* Map Products */}
                <div className='grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-y-6'>
                    {
                        filterProducts.map((item, index) => (
                            <ProductItem key={index} name={item.productname} id={item.productid} price={item.productpriceS} image={item.productimage} />
                        ))
                    }
                </div>
            </div>

        </div >
    )
}

export default Collection