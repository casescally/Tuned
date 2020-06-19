import React, { useContext, useState, useEffect } from "react"
import { Link } from "react-router-dom"
import { UserContext } from "../user/UserProvider"
import { getUser } from "../../API/userManager"
import "./Users.css"

export default ({ UserCard }) => {

    //const { users } = useContext(UserContext)
    const user = getUser()

    return (

        <section className="userSection">

            <div className="userInfo">

                <h3 className="user__name">

                    <Link to={`/profile/${user.id}`}>

                        <div className="car__user">{user.firstName + ' ' + user.lastName}</div>

                    </Link>

                </h3>

            </div>

        </section>

    )

}