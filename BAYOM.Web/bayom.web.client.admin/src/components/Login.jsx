import axios from 'axios';
import React, { useState } from 'react'
import { backendUrl } from '../App';
import { toast } from 'react-toastify';


function Login({ setToken }) {

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const onSumbitHandler = async (e) => {
        console.log(email)
        console.log(password)
        try {
            e.preventDefault();
            const response = await axios.post(`${backendUrl}/api/Users/authenticate`,
                null, // Body gönderilmeyecek
                {
                    params: {
                        email: email, // Query string parametreleri
                        password: password,
                    },
                    headers: { 'Content-Type': 'application/json' },
                }
            );

            if (response.data.token) {
                setToken(response.data.token);
                console.log(response.data.token)
            } else {
                toast.error(response.data.message);
            }
        }
        catch (error) {
            console.log(error.response?.data);
            toast.error(error.message)
        }

    }
    return (
        <div className='min-h-screen flex items-center justify-center w-full'>
            <div className='bg-white shadow-md rounded-lg px-8 py-6 max-w-md'>
                <h1 className='text-2xl font-bold mb-4'>Admin Panel</h1>
                <form onSubmit={onSumbitHandler}>
                    <div className='mb-3 min-w-72'>
                        <p className='text-sm font-medium text-gray-700 mb-2'>Email Adress</p>
                        <input onChange={(e) => setEmail(e.target.value)} value={email} className='rounded-md w-full px-3 py-2 border border-gray-300 outline-none' type='text' placeholder='your@email.com' required />
                    </div>
                    <div className='mb-3 min-w-72'>
                        <p className='text-sm font-medium text-gray-700 mb-2'>Password</p>
                        <input onChange={(e) => setPassword(e.target.value)} value={password} className='rounded-md w-full px-3 py-2 border border-gray-300 outline-none' type='password' placeholder='Enter Your Password' required />
                    </div>
                    <button className='mt-2 w-full py-2 px-4 rounded-md bg-black text-white' type="submit">Login</button>
                </form>
            </div>
        </div>
    )
}

export default Login