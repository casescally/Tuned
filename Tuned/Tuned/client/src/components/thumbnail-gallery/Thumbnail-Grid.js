import React from 'react'
import Thumbnail from './Thumbnail'

const ThumbnailGrid = ({ thumbnails, handleClick, editMode, handleRemoveImage }) => {
    return (
        <div style={styles}>
            {
                thumbnails.map((thumbnail, i) => {
                    return (
                        <Thumbnail
                            editMode={editMode}
                            key={i}
                            imgUrl={thumbnail}
                            handleClick={() => handleClick(i)}
                            handleRemoveImage={handleRemoveImage}
                            index={i}
                        />
                    )
                })

            }
            <div className="divider div-transparent"></div>
        </div>
        
    )
}

const styles = {
    height: '35%',
    width: '100%',
    background: '',
    display: 'flex',
    flexWrap: 'wrap'
}

export default ThumbnailGrid