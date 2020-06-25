import React from 'react'

const Thumbnail = ({ imgUrl, handleClick, editMode, handleRemoveImage, index }) => {

    return (
        <div className="carThumbnail" style={styles}>
            <img
                src={imgUrl.startsWith('blob') ? imgUrl : `https://localhost:5001/api/CarImages/image/get?imageName=${imgUrl}`}
                style={{
                    width: '100%',
                    height: '100%'
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