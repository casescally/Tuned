import React, { useContext, useReducer } from "react"
import { Link } from "react-router-dom"
import { LikedCarContext } from "../likedcars/LikedCarsProvider"
import { UserContext } from "../user/UserProvider"
import "../car/Cars.css"

export default ({ likedcar }) => {

    const { users } = useContext(UserContext)

    const { likedcars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)

    const user = users.find(u => u.id === likedcar.userId) || {}

    const currentLikedCars = likedcars.filter(l => l.carId === likedcar.id)

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCar = likedcars.find(likedcar => likedcar.carId === currentcar.id && likedcar.userId === parseInt(localStorage.getItem("currentUser")))

        const user = users.find(u => u.id === likedcar.userId) || {}

        //Don't allow duplicate likedcars

        if (alreadyLikedCar === undefined) {

            likedcarMode = false

            addLikedCar({

                carId: currentCar.id,

                userId: parseInt(localStorage.getItem("currentUser"))

            })

        } if (alreadyLikedCar !== undefined) {

            likedcarMode = true

            deleteLikedCar(likedcars.find(likedcar => likedcar.carId === currentCar.id && likedcar.userId === parseInt(localStorage.getItem("currentUser"))))

        }

    }

    let likedcarMode = Boolean

    return (

        <section className="likedCarSection">

            <img className="coverImage" src={likedcar.CarPageCoverUrl} alt={`${likedcar.name} cover image`}></img>

            <div className="carUploader">

                <h3>

                    <Link to={`/users/${likedcar.userId}`}>

                        <div className="car__user">{user.name}</div>

                    </Link>

                </h3>

                <h3 className="car__name">

                    <Link className="carLink" to={`/cars/${likedcar.id}`}>

                        {likedcar.name}

                    </Link>

                </h3>

            </div>

            <div className="likedcarInfo">

                LikedCars: {currentLikedCars.length}

                <button className="likedcarButton" value="LikedCar" onClick={evt => {

                    evt.preventDefault()

                    constructNewLikedCar(likedcar)

                }

                }>{likedcarMode ? "LikedCar" : "Unlikedcar"}</button>

                <div className="uploaderInfo">


                </div>

            </div>

        </section>

    )

}