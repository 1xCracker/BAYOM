import React from 'react'
import { assets } from '../assets/assets'

function Footer() {
    return (
        <div>
            <div className='flex flex-col sm:grid grid-cols-[3fr_1fr_1fr] gap-14 my-10 mt-40 text-sm'>
                <div>
                    <img src={assets.logo} className='mb-5 w-44' alt="" />
                    <p className='w-full md:w-2/3 text-gray-600'>
                        Bayotech was established to combine quality, innovation, and reliability in the computer and technology industry, providing customers with a unique shopping experience.
                    </p>
                </div>
                <div>
                    <p className='text-xl font-medium mb-5'>COMPANY</p>
                    <ul className='flex flex-col gap-1 text-gray-600'>
                        <li>Home</li>
                        <li>About us</li>
                        <li>Delivery</li>
                        <li>Privacy policy</li>
                    </ul>
                </div>
                <div>
                    <p className='text-xl font-medium mb-5'>GET IN TOUCH</p>
                    <ul className='flex flex-col gap-1 text-gray-600'>
                        <li>+90-553-562-75-34</li>
                        <li>contact@bayotechyazilim.com</li>
                    </ul>
                </div>

            </div>
            <div >
                <hr />
                <p className='py-5 text-sm text-center'>Copyright 2025@ bayotech.com - All Right Reserved.</p>
            </div>
        </div>
    )
}

export default Footer