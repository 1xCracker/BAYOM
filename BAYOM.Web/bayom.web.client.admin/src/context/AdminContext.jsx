import axios from 'axios';
import React, { createContext, useEffect, useState } from 'react'
import { backendUrl } from '../App';

export const AdminContext = createContext()
function AdminContextProvider(props) {

    const [categories, setCategory] = useState([]);
    const [topCategories, setTopCategory] = useState([]);
    const [brands, setBrand] = useState([]);

    const fetchData = async () => {
        try {
            const categoryData = await axios.get(`${backendUrl}/api/CategoryBrand/GetAllCategory`);

            setCategory(categoryData.data);

            const topCategoryData = await axios.get(`${backendUrl}/api/CategoryBrand/TopCategory`);
            setTopCategory(topCategoryData.data)
            const brandData = await axios.get(`${backendUrl}/api/CategoryBrand/ProductBrand`);
            setBrand(brandData.data);
        } catch (error) {
            console.error("Veri çekilirken bir hata oluştu:", error);
        }
    };


    useEffect(() => {
        fetchData();
    }, []);

    const value = { categories, topCategories, brands }
    return (
        <AdminContext.Provider value={value}>
            {props.children}
        </AdminContext.Provider>
    )
}

export default AdminContextProvider