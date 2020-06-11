import React, { useState, useEffect, useContext } from 'react';
import { createAuthHeaders } from '../API/userManager';
import { CarContext } from "./car/CarProvider"
import Car from "./car/Car"

function Home() {
  const [values, setValues] = useState([]);

  // useEffect(() => {
  //   const authHeader = createAuthHeaders();
  //   fetch('/api/v1/values', {
  //     headers: authHeader
  //   })
  //     .then(response => response.json())
  //     .then(setValues);
  // }, []);



  return (
    <>
      <h1>Welcome to my app</h1>
    </>
  )
}

export default Home;