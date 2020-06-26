import React from 'react'
import carThumbnail from './Thumbnail-Gallery'

const Thumbnail = ({ imgUrl, handleClick, editMode, handleRemoveImage, index }) => {

    return (
        <div className="carThumbnail" style={styles}>
            <img
                className="carThumbnailImage"
                src={imgUrl.startsWith('blob') ? imgUrl : `https://localhost:5001/api/CarImages/image/get?imageName=${imgUrl}`}
                style={{
                    height: '100%',
                    width: '100%'
                }}
                onClick={handleClick}
            />
            {editMode && <button type="button" style={buttonStyle} className="thumbnailDeleteButton" onClick={() => handleRemoveImage(index)}>Delete</button>}
        </div>
    )

}

const buttonStyle = {
    display: 'block',
    position: 'relative',
    bottom: '30px',
    left: '5px'
}

const styles = {
    height: '50%',
    width: '25%',
    position: 'relative'
}

export default Thumbnail