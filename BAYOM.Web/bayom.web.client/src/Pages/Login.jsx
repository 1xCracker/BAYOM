import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { backendUrl } from '../App';
import { toast } from 'react-toastify';

function Login() {
    const [currencyState, setCurrencyState] = useState('Login');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phone, setPhone] = useState('');
    const [adress, setAdress] = useState('');
    const [token, setToken] = useState('');
    const onSubmitHandler = async (e) => {
        e.preventDefault();

        if (currencyState == 'Login') {
            try {

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

                } else {
                    toast.error(response.data.message);
                }
            }
            catch (error) {

                toast.error(error.message)
            }
        }
        else {
            try {
                const response = await axios.post(`${backendUrl}/api/Users/SignUp`, {
                    useremail: email,
                    userpassword: password,
                    customerfirstname: name,
                    customerlastname: surname,
                    customerphonenumber: phone,
                    customeradress: adress,
                    customeremail: email
                }, {
                    headers: { 'Content-Type': 'application/json' }
                });
                toast.success('Success!', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: false,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "light",

                });
                setCurrencyState('Login')
            } catch (error) {
                toast.error(error.response?.data || error.message);
            }

        }
    }
    useEffect(() => {

    }, [currencyState]);
    return (
        <form onSubmit={onSubmitHandler} className='flex flex-col items-center w-[90%] sm:max-w-96 m-auto mt-14 gap-4 text-gray-800'>
            <div className='inline-flex items-center gap-2 mb-2 mt-10'>
                <p className='prata-regular text-3xl'>{currencyState}</p>
                <hr className='border-none h-[1.5px] w-8 bg-gray-800' />
            </div>
            {currencyState === 'Login' ? '' : (
                <>
                    <input onChange={(e) => setName(e.target.value)} value={name} type='text' className='w-full px-3 py-2 border border-gray-800' placeholder='Name' required />
                    <input onChange={(e) => setSurname(e.target.value)} value={surname} type='text' className='w-full px-3 py-2 border border-gray-800' placeholder='Surname' required />
                    <input onChange={(e) => setPhone(e.target.value)} value={phone} type='text' className='w-full px-3 py-2 border border-gray-800' placeholder='Phone' required />
                    <input onChange={(e) => setAdress(e.target.value)} value={adress} type='text' className='w-full px-3 py-2 border border-gray-800' placeholder='Adress' required />


                </>)


            }
            <input onChange={(e) => setEmail(e.target.value)} value={email} type='email' className='w-full px-3 py-2 border border-gray-800' placeholder='Email' required />
            <input onChange={(e) => setPassword(e.target.value)} value={password} type='password' className='w-full px-3 py-2 border border-gray-800' placeholder='Password' required />
            <div className='w-full flex justify-between text-sm mt-[-8px]'>
                <p className='cursor-pointer'>Forgot your password</p>{
                    currencyState === 'Login' ? <p onClick={() => setCurrencyState('Sign Up')} className='cursor-pointer'>Create account</p> : <p onClick={() => setCurrencyState('Login')} className='cursor-pointer'>Login Here</p>
                }
            </div>
            <button className='bg-black text-white font-light px-8 py-2 mt-4'>{currencyState === 'Login' ? 'Sign in' : 'Sign up'}</button>
        </form>
    )
}

export default Login