import React, { useContext, useState } from "react"

import { Link } from "react-router-dom"

import { LikedCarContext } from "../likedCar/LikedCarProvider"

import { UserContext } from "../user/UserProvider"

import "./Cars.css"



export default ({ car }) => {



    const { users } = useContext(UserContext)

    const { likedcars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)

    const user = users.find(u => u.id === car.userId) || {}

    const currentCarsLikedCars = likedcars.filter(likedcar => likedcar.carId === car.id)

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCardCar = likedcars.find(likedcar => likedcar.carId === currentCar.id && likedcar.userId === parseInt(localStorage.getItem("currentUser")))

        const user = users.find(u => u.id === car.userId) || {}



        //Don't allow duplicate likedcars

        if (alreadyLikedCardCar === undefined) {

            likedcardCarMode = false

            addLikedCar({

                carId: currentCar.id,

                userId: parseInt(localStorage.getItem("currentUser"))

            })

        } if (alreadyLikedCardCar !== undefined) {

            likedcardCarMode = true

            deleteLikedCar(likedcars.find(likedcar => likedcar.carId === currentCar.id && likedcar.userId === parseInt(localStorage.getItem("currentUser"))))

        }

    }



    let likedcardCarMode = Boolean



    return (



        //car information

        <section className="carSection">

            <div className="carInfo">


                <img className="coverImage" src={car.carCoverUrl}></img>











                <div className="carUploader">



                    <h3>

                        <Link to={`/users/${car.userId}`}>



                            <div className="car__user">{user.username}</div>

                        </Link>

                    </h3>



                    {/* {console.log(currentCarsLikedCars)} */}



                    <h3 className="car__name">



                        <Link to={`/cars/${car.id}`} className="carLink">

                            {car.name}

                        </Link>



                    </h3>



                </div>

            </div>

            <div className="likedcarInfo">



                LikedCars: {currentCarsLikedCars.length}

                <button className="likedcarButton" value="LikedCar" onClick={evt => {

                    evt.preventDefault()



                    constructNewLikedCar(car)

                }

                }>{likedcardCarMode ? "LikedCar" : "Unlikedcar"}</button>









            </div>







            <div className="uploaderInfo">



            </div>





        </section>

    )

}