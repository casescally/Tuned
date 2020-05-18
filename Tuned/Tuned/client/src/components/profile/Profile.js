import React, { useContext } from "react"
import { CarContext } from "../car/CarProvider"
import Car from "../car/Car"
import "../car/Cars.css"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import LikedCar from "../likedCar/LikedCar"
import "./Profiles.css"
import { getUser } from "../../API/userManager"

export default (props) => {

    const { cars } = useContext(CarContext)
    const { users } = useContext(UserContext)
    const userName = JSON.parse(localStorage.getItem("user")).username
    const { likedCars } = useContext(LikedCarContext)
    const currentUser = getUser()
    const profilesArray = []

    let editProfileMode = Boolean

    if (userName !== JSON.parse(localStorage.getItem("user")).username) {
        let foundProfile = users.find(u => u.id === userName) || {}
        editProfileMode = false
        profilesArray.push(foundProfile)

    } else {
        let foundProfile = users.find(u => u.id === userName) || {}
        editProfileMode = true
        profilesArray.push(foundProfile)

    }

    //const currentProfile = profilesArray[0]

    //console.log("User Profile")

    // //const likesRelationships = likes.filter(like => like.userId === currentProfile.id)
    // const currentUsersLikes = []

    // {
    //     likesRelationships.forEach(rel => {

    //         // Find this relationships's matching user object
    //         const foundLike = cars.filter(
    //             (singleCar) => {
    //                 return rel.carId === singleCar.id
    //             }
    //         )[0]

    //         //if page is reloaded and no likes are found
    //         if (foundLike !== undefined) {
    //             currentUsersLikes.push(foundLike)
    //         }
    //     })
    // }

    const currentUserCars = cars.filter(car => {

        return car.applicationUserId === currentUser.id

    })

    const currentUsersLikedCars = [];

    {
        likedCars.forEach(rel => {

            // Find the user
            const foundLike = cars.filter(
                (car) => {
                    return rel.applicationUserId === car.applicationUserId
                }
            )[0]
            //if page is reloaded and no likes are found
            if (foundLike !== undefined) {
                currentUsersLikedCars.push(foundLike)
            }
        })
    }
    console.log(likedCars)
    return (

        <div className="profile">

            <section className="userProfile">

                <div className="profileBackground" style={{
                    backgroundImage: "url(" + `${currentUser.name}` + ")",
                    backgroundPosition: 'center',
                    // backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    objectFit: 'contain',
                    maxwidth: '100%'
                }}>

                    <span id="profileInfo">



                        {<h1 className="currentProfileName">{currentUser.userName}</h1>}


                        {

                            <button className="followButton" onClick={evt => {

                                evt.preventDefault()
                                props.history.push(`edit/${currentUser.userName}`)

                            }}>{editProfileMode ? "Edit" : ""}

                            </button>}
                    </span>
                </div>



                <div className="mainProfileSection">
                    <article className="profileCarList">
                        <h3>Cars: {currentUserCars.length}</h3>

                        {currentUserCars.map(car => <Car key={car.id} car={car} {...props} />)}

                    </article>

                    <div className="profileSidebar">

                        <article id="profileCarCollections">


                        </article>

                        <article id="likedCars" className="profileLikesList">

                            <h3>Liked Cars</h3>

                            {currentUsersLikedCars.map(car => <Car key={car.id} car={car} {...props} />)}

                        </article>
                    </div>

                </div>
            </section>
        </div>
    )
}