import React, { useContext } from "react"
import { CarContext } from "./CarProvider"
import Car from "./Car"
import "./Cars.css"

export function CarList(props) {
    const { cars } = useContext(CarContext)

    return (
        <>
            <h1>Cars</h1>

            <button onClick={() => props.history.push("/cars/create")}>
                Add Car
            </button>
            <div className="cars">
                {
                    cars.map(car => {
                        return <Car key={car.id} car={car} />
                    })
                }
            </div>
        </>
    )
}