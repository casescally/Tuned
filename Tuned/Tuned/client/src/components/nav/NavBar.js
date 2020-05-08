
import React from "react"
import { Link } from "react-router-dom"
import "./NavBar.css"

export default (props) => {

    return (

        <ul className="navbar">

            <li className="navbar__item profile">

                <Link className="navbar__link" to="/">Profile</Link>

            </li>

            <li className="navbar__item searchBar">

                <input type="search" placeholder="Search"></input>

            </li>

            <li className="navbar__item profile">

                <Link className="navbar__link" to={`/users/${parseInt(localStorage.getItem("currentUser"))}`}>Profile</Link>

            </li>

            <li className="navbar__item upload">

                <button className="navBarUploadButton" onClick={() => props.history.push("/cars/create")}>

                    Add Vehicle

                </button>

            </li>

            {

                localStorage.getItem("currentUser")

                    ? <li className="navbar__item">

                        <Link className="navbar__link"

                            to=""

                            onClick={e => {

                                e.preventDefault()

                                localStorage.removeItem("currentUser")

                                props.history.push("/")

                            }}

                        >Logout</Link>

                    </li>
                    : ""
            }
        </ul>
    )
}