import React, { useState, useCallback, useContext } from "react";
// import { createAuthHeaders } from '../API/userManager';
import { CarContext } from "./car/CarProvider";
import { LikedCarContext } from "./likedCar/LikedCarProvider";
import Car from "./car/Car";

function Home() {
  const { cars } = useContext(CarContext);
  const [carImages, setCarImages] = useState([]);
  const { likedCars } = useContext(LikedCarContext);
  let top5LikedCars = likedCars.sort((a, b) => b - a).slice(0, 5);
  let top5LikedCarsImages = cars.filter((car) => car.id === top5LikedCars.carId)
  console.log("nncarObjIMAG====>>", top5LikedCarsImages);
  //const [values, setValues] = useState([]);

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
  );
}

export default Home;
