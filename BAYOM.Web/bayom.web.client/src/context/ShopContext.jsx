import { createContext, useEffect, useState } from "react";
import React from "react";
import { products } from "../assets/assets";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";

export const ShopContext = createContext();
function ShopContextProvider(props) {

    const currency = '₺'
    const delivery_fee = 10;
    const [search, setSearch] = useState('');
    const [showSearch, setShowSearch] = useState(false)
    const [cartItems, setCartItems] = useState({});
    const [product, setProduct] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        productData();
        
    }, []);

    const addToCart = async (itemId, size) => {
        if (!size) {
            toast.error('Select Product Size')
            return;
        }


        let cartData = structuredClone(cartItems);

        if (cartData[itemId]) {
            if (cartData[itemId][size]) {
                cartData[itemId][size] += 1;
            }
            else {
                cartData[itemId][size] = 1;
            }
        }
        else {
            cartData[itemId] = {};
            cartData[itemId][size] = 1
        }
        setCartItems(cartData);
    }




    const getCartCount = () => {
        let totalCount = 0
        for (const items in cartItems) {
            for (const item in cartItems[items]) {
                try {
                    if (cartItems[items][item] > 0) {
                        console.log(cartItems[items][item])
                        totalCount += cartItems[items][item];
                    }
                }
                catch (error) {
                }
            }
        }
        return totalCount;
    }

    const updateQuantity = async (itemId, size, quantity) => {
        let cartData = structuredClone(cartItems);
        cartData[itemId][size] = quantity;
        setCartItems(cartData);
    }

    const getCartAmount = () => {
        let totalAmount = 0;
        for (const items in cartItems) {

            let itemInfo = products.find((product) => product.id == items);
            console.log(itemInfo)
            for (const item in cartItems[items]) {
                try {
                    if (cartItems[items][item] > 0) {
                        totalAmount += itemInfo.price * cartItems[items][item]
                    }
                }
                catch (error) {

                }
            }
            console.log(totalAmount)
        }
        return totalAmount;
    }

    const value = {
        products, currency, delivery_fee,
        search, setSearch, showSearch, setShowSearch,
        cartItems, addToCart, getCartCount, updateQuantity
        , getCartAmount, navigate, product
    }

    return (
        <ShopContext.Provider value={value}>
            {props.children}
        </ShopContext.Provider>
    )
    async function productData() {
        const response = await fetch('https://localhost:7021/api/Products');
        const data = await response.json();

        setProduct(data);
    }
}

export default ShopContextProvider;