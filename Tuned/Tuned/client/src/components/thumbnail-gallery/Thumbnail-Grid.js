import React from 'react'
import Thumbnail from './Thumbnail'

const ThumbnailGrid = ({ thumbnails, handleClick }) => {
    return (
        <div style={styles}>
            {
                thumbnails.map((thumbnail, i) => {
                    return (
                        <Thumbnail
                            key={thumbnail.imgUrl}
                            imgUrl={thumbnail.imgUrl}
                            handleClick={handleClick}
                            index={i}
                        />
                    )
                })

            }
        </div>
    )
}

const styles = {
    height: '35%',
    width: '100%',
    background: 'yellow',
    display: 'flex',
    flexWrap: 'wrap'
}

export default ThumbnailGrid