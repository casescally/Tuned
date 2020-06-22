import React from 'react'

const Thumbnail = ({ imgUrl, handleClick, editMode, handleRemoveImage, index }) => {
    console.log('edddd==>>', editMode)
    return (
        <div style={styles}>
            <img
                src={imgUrl.startsWith('blob') ? imgUrl : `https://localhost:5001/api/CarImages/image/get?imageName=${imgUrl}`}
                style={{
                    width: '100%',
                    height: '100%'
                }}
                onClick={handleClick}
            />
            {editMode && <button type="button" onClick={() => handleRemoveImage(index)}>Delete</button>}
        </div>
    )

}

const styles = {
    height: '50%',
    width: '25%',
    position: 'relative'
}

export default Thumbnail