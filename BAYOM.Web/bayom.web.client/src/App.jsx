import React from 'react'
import { Routes, Route } from 'react-router-dom'
import Home from './Pages/Home'
import About from './Pages/About'
import Collection from './Pages/Collection'
import Contact from './Pages/Contact'
import Product from './Pages/Product'
import Cart from './Pages/Cart'
import Login from './Pages/Login'
import PlaceOrder from './Pages/PlaceOrder'
import Order from './Pages/Order'
import Navbar from './components/navbar'
function App() {
    return (
        <div className="px-4 sm:px-[5vw] md:px-[7vw] lg:px-[9vw]">
            <Navbar />
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path='/collection' element={<Collection />} />
                <Route path='/about' element={<About />} />
                <Route path='/contact' element={<Contact />} />
                <Route path='/product' element={<Product />} />
                <Route path='/cart' element={<Cart />} />
                <Route path='/login' element={<Login />} />
                <Route path='/place-order' element={<PlaceOrder />} />
                <Route path='/order' element={<Order />} />


            </Routes>
        </div>
    )
}

export default App