import { createContext, useEffect, useState } from "react";

import { useNavigate } from "react-router-dom";
import { backendUrl } from "../App";

export const ShopContext = createContext();
function ShopContextProvider(props) {

    const currency = '₺'
    const delivery_fee = 10;
    const [search, setSearch] = useState('');
    const [showSearch, setShowSearch] = useState(false)
    const [cartItems, setCartItems] = useState({});
    const [product, setProduct] = useState([]);
    const [productLast, setProductLast] = useState([]);
    const [topCategory, setTopCategory] = useState([]);
    const [productBrand, setProductBrand] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        productData();
        LastproductData();
        productBrandData();
        topCategoryData();

    }, []);

    const addToCart = async (itemId) => {
        let cartData = structuredClone(cartItems);

        // Eğer bu itemId zaten sepette varsa, miktarını artır
        if (cartData[itemId]) {
            cartData[itemId] += 1;
        }
        // Eğer bu itemId sepette yoksa, yeni ürün ekle
        else {
            cartData[itemId] = 1;  // Başlangıç miktarı 1
        }
        // Sepet verisini güncelle
        setCartItems(cartData);

    }

    const getCartCount = () => {
        let totalCount = 0
        for (const items in cartItems) {
            try {
                if (cartItems[items] > 0) {
                    totalCount += cartItems[items];
                }
            }
            catch (error) {
                console.log(error)
            }
        }
        return totalCount;
    }

    const updateQuantity = async (itemId, quantity) => {
        let cartData = structuredClone(cartItems);
        cartData[itemId] = quantity;
        setCartItems(cartData);

    }

    const getCartAmount = () => {
        let totalAmount = 0;
        for (const items in cartItems) {

            let itemInfo = product.find((product) => product.productid == items);
            console.log(itemInfo)
            try {
                if (cartItems[items] > 0) {
                    totalAmount += itemInfo.productpriceS * cartItems[items]
                }
            }
            catch (error) {
                console.log(error)
            }
        }
        return totalAmount;
    }

    const value = {
        currency, delivery_fee,
        search, setSearch, showSearch, setShowSearch,
        cartItems, addToCart, getCartCount, updateQuantity
        , getCartAmount, navigate, product, productLast, productBrand, topCategory
    }

    return (
        <ShopContext.Provider value={value}>
            {props.children}
        </ShopContext.Provider>
    )
    async function productData() {
        const response = await fetch(`${backendUrl}/api/Products/all`);
        const data = await response.json();
        setProduct(data);
    }
    async function LastproductData() {
        const response = await fetch(`${backendUrl}/api/Products/latest`);
        const data = await response.json();
        setProductLast(data);
    }
    async function topCategoryData() {
        const response = await fetch(`${backendUrl}/api/CategoryBrand/TopCategory`);
        const data = await response.json();
        setTopCategory(data);
    }
    async function productBrandData() {
        const response = await fetch(`${backendUrl}/api/CategoryBrand/ProductBrand`);
        const data = await response.json();
        setProductBrand(data);
    }

}

export default ShopContextProvider;