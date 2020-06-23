import React, { useContext } from "react"
import { Link } from "react-router-dom"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { UserContext } from "../user/UserProvider"
import { getUser } from "../../API/userManager"
import "../car/Cars.css"

export default ({ car }) => {

    const { users } = useContext(UserContext)
    const { likedCars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)
    const carUser = users.find(u => u.id === car.userId) || {}
    const user = getUser()

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCarRel = likedCars.find(likedCar => likedCar.carId == currentCar.id && likedCar.user.id === user.id)

        //Don't allow duplicate liked cars
        if (alreadyLikedCarRel === undefined || null) {

            likedCarMode = false

            addLikedCar({

                carId: currentCar.id,

                userId: user.id

            })

        } else if (alreadyLikedCarRel !== undefined || null) {

            likedCarMode = true

            deleteLikedCar(alreadyLikedCarRel)

        }

    }

    let likedCarMode = Boolean

    return (

        <section className="carSection">

            <div className="carInfo">


                <img className="coverImage" src={car.carCoverUrl}></img>

                <div className="carUploader">

                    <h3>

                        <Link to={`/users/${car.userId}`}>


                            <div className="car__user">{carUser.username}</div>

                        </Link>

                    </h3>

                    <h3 className="car__name">

                        <Link to={`/cars/${car.id}`} className="carLink">

                            {car.name}

                        </Link>

                    </h3>

                </div>

            </div>

            <div className="likedcarInfo">

                <button className="likedcarButton" value="LikedCar" onClick={evt => {

                    evt.preventDefault()

                    constructNewLikedCar(car)

                }

                }>{likedCarMode ? "Like" : "Unlike"}</button>

            </div>

            <div className="uploaderInfo">

            </div>

        </section>

    )

}