import React from 'react'
import Title from '../components/Title'
import { assets } from '../assets/assets'
import NewsletterBox from '../components/NewsletterBox'

function About() {
    return (
        <div>
            <div className='text-2xl text-center pt-8 border-t'>
                <Title text1={'ABOUT'} text2={'US'} />
            </div>
            <div className='my-10 flex flex-col md:flex-row gap-16' >
                <img className='w-full md:max-w-[450px]' src={assets.about_us_1} alt='bayotech' />
                <div className='flex flex-col justify-center gap-6 md:w-2/4 text-gray-600'>
                    <p>



                        Bayotech was established to combine quality, innovation, and reliability in the computer and technology industry, providing customers with a unique shopping experience. Our extensive product range includes everything from complete computer systems to components, gaming equipment, and peripherals, tailored to meet every need.

                        In today's rapidly evolving tech landscape, we don’t just offer products—we offer guidance and expertise. At Bayotech, our mission is to help you choose the right products, find the latest solutions, and exceed your expectations.

                    </p>
                    <b className='text-gray-800'>Our Vision</b>
                    <p>
                        We aim to be a trusted leader in the tech industry, pioneering innovations and remaining the top choice for our customers.
                    </p>
                    <b className='text-gray-800'>Our Mission</b>
                    <p>      Bayotech strives to be the go-to destination for tech enthusiasts and professionals alike. Our goal is to make high-performance technology accessible to everyone by delivering premium products at competitive prices.</p>
                </div>
            </div>
            <div className='text-xl py-4'>
                <Title text1={'WHY'} text2={'CHOOSE US'} />
            </div>
            <div className='flex flex-col md:flex-row text-sm mb-20'>
                <div className='border px-10  md:px-16 py-8 sm:py-20 flex flex-col gap-5'>
                    <p>  Quality and Trust: Every product at Bayotech is carefully selected to ensure maximum customer satisfaction.
                        Competitive Prices: We provide solutions that fit your budget without compromising on performance.
                        Expert Support: Our knowledgeable team is ready to assist you before and after your purchase, answering your questions and offering tailored recommendations.
                        Diverse Product Range: From desktop computers to laptops, graphic cards to processors, you’ll find everything under one roof.

                        Bayotech is more than just a store—we're your trusted partner for everything tech.</p>
                </div>
            </div>
            <NewsletterBox />
        </div>
    )
}

export default About