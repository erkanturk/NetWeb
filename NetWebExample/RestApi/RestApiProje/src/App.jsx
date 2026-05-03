import { useEffect, useState } from 'react'

import axios from 'axios'
import './App.css'

function App() {
 const[products,setProducts]=useState([])
 const[errorHandler,setErrorHandler]=useState(false)
 useEffect(()=>{
  axios.get("https://localhost:7273/api/Product/GetProducts")
  .then((res)=>{
    console.log(res)
    if(res.status===200)
    {
      setProducts(res.data)
    }
  })
  .catch((e)=>{
    if(e.response.data.status===404)
    {
      setErrorHandler(true)
    }
    console.log(e)
  })
 },[])

  return (
    <>
      {errorHandler?"Bir Hata oluştu":products.map((product,key)=>
      <div key={key}>
        <h3>{product.title}</h3>
        <p>{product.description}</p>
        <p>{product.price}</p>
        <p>{product.Category}</p>

      </div>
      )}
    </>
  )
}

export default App
