import React, { Component } from "react"
import Dropzone from 'react-dropzone'
import ActiveThumbnailWindow from './Active-Thumbnail-Window'
import ThumbnailGrid from './Thumbnail-Grid'
import "./Thumbnail-Gallery.css"

export default class ThumbnailGallery extends Component {

    state = {
        activeIndex: 0
    }

    renderThumbnails = () => {

        const { activeIndex } = this.state;
        const { images, editMode, handleAddImages, setCarImages } = this.props
        console.log(images[activeIndex])

        return (
            editMode ?
                <Dropzone onDrop={handleAddImages}
                >
                    {({ getRootProps, getInputProps }) => (
                        <section>
                            <div {...getRootProps()}>
                                <input {...getInputProps()} />

                                {images.length ? <ActiveThumbnailWindow
                                    activeThumbnail={images[activeIndex]}

                                /> : (
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
            <div className="activeThumbnailWindow" style={thumbnailGalleryStyles}>

                <div style={{ flex: 1 }}>
                    {this.renderThumbnails()}

                    {images.length > 0 && <ThumbnailGrid
                        thumbnails={images}
                        editMode={editMode}
                        handleClick={this.handleClick}
                        handleRemoveImage={handleRemoveImage}
                    />}

                </div>

            </div>
        )
    }
}

const thumbnailGalleryStyles = {
    background: '#ddd',
    width: '1024px',
    margin: '40px auto',
    display: 'flex'
}