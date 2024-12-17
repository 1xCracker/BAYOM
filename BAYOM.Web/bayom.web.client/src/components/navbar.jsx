import React from 'react'
import { assets } from '../assets/assets'
function navbar() {
    return (
        <div className='flex items-center justify-between py-5 font-medium'>
            <img src={assets.logo} className='w-52' alt="Bayo-tech-logo" />

        </div>
    )
}

export default navbar