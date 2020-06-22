import React, { Component, useState, useContext, useEffect } from "react"
import Dropzone from 'react-dropzone'
import ActiveThumbnailWindow from './Active-Thumbnail-Window'
import ThumbnailGrid from './Thumbnail-Grid'
import { CarContext } from "../car/CarProvider"
import { createAuthHeaders } from "../../API/userManager"

//const { cars, getCars } = useContext(CarContext)

export default class ThumbnailGallery extends Component {

    state = {
        activeIndex: 0
    }


    renderThumbnails = () => {
        const { activeIndex } = this.state;
        const { images, editMode, handleAddImages } = this.props

        return (
            editMode ?
                <Dropzone onDrop={handleAddImages}>
                    {({ getRootProps, getInputProps }) => (
                        <section>
                            <div {...getRootProps()}>
                                <input {...getInputProps()} />

                                {images.length ? <ActiveThumbnailWindow
                                    activeThumbnail={images[activeIndex]} /> : (
                                        <div>
                                            <p>Drop the files here ...</p> :
                                            <p>Drag 'n' drop some files here, or click to select files</p>
                                        </div>
                                    )}
                            </div>
                        </section>
                    )}
                </Dropzone>
                : images.length > 0 && <ActiveThumbnailWindow
                    activeThumbnail={images[activeIndex]} />
        )

    }

    handleClick = activeIndex => {
        this.setState({ activeIndex })
    }

    render() {
        const { images, handleRemoveImage, editMode } = this.props

        return (
            <div style={thumbnailGalleryStyles}>


                {/*Left Side*/}

                <div style={{ flex: 1 }}>
                    {this.renderThumbnails()}

                    {images.length > 0 && <ThumbnailGrid
                        thumbnails={images}
                        editMode={editMode}
                        handleClick={this.handleClick}
                        handleRemoveImage={handleRemoveImage}
                    />}

                </div>
                {/*Right Side*/}
                <div style={{ flex: 1, padding: '40px' }}>
                    {/* Text Area */}
                </div>

            </div>
        )
    }
}

const thumbnailGalleryStyles = {
    background: '#ddd',
    height: '500px',
    width: '1024px',
    margin: '40px auto',
    display: 'flex'
}