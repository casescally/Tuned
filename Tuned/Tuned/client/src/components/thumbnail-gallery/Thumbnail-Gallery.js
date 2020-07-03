import React, { Component, useState } from "react";
import Dropzone from "react-dropzone";
import ActiveThumbnailWindow from "./Active-Thumbnail-Window";
import ThumbnailGrid from "./Thumbnail-Grid";
import "./Thumbnail-Gallery.css";

export default class ThumbnailGallery extends Component {
  state = {
    activeIndex: 0,
  };

  renderThumbnails = () => {
    const { activeIndex } = this.state;
    const {
      images,
      editMode,
      handleAddImages,
      updateCarsCoverImage,
    } = this.props;
    //console.log(images[activeIndex])

    return editMode ? (
      <Dropzone onDrop={handleAddImages}>
        {({ getRootProps, getInputProps }) => (
          <section>
            <button
              type="button"
              onClick={() =>{
                console.log(images[activeIndex])
                 updateCarsCoverImage(images[activeIndex])}
              }>
              Set Cover Image
            </button>
            <div {...getRootProps()}>
              <input {...getInputProps()} />

              {images.length ? (
                <ActiveThumbnailWindow activeThumbnail={images[activeIndex]} />
              ) : (
                <div>
                  <p>Drop the files here ...</p> :
                  <p>Drag 'n' drop some files here, or click to select files</p>
                </div>
              )}
            </div>
          </section>
        )}
      </Dropzone>
    ) : (
      images.length > 0 && (
        <ActiveThumbnailWindow activeThumbnail={images[activeIndex]} />
      )
    );
  };

  handleClick = (activeIndex) => {
    this.setState({ activeIndex });
  };

  render() {
    const { images, handleRemoveImage, editMode } = this.props;

    return (
      <div className="activeThumbnailWindow" style={thumbnailGalleryStyles}>
        <div style={{ flex: 1 }}>
          {this.renderThumbnails()}

          {images.length > 0 && (
            <ThumbnailGrid
              thumbnails={images}
              editMode={editMode}
              handleClick={this.handleClick}
              handleRemoveImage={handleRemoveImage}
            />
          )}
        </div>
      </div>
    );
  }
}

const thumbnailGalleryStyles = {
  background: "white",
  width: "1024px",
  margin: "40px auto",
  display: "flex",
};
