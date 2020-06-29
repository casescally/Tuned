import React from "react";


const ActiveThumbnailWindow = ({ activeThumbnail }) => {


    if (activeThumbnail) {
        return (
            <div style={styles}>
                <img
                    src={activeThumbnail.startsWith('blob') ? activeThumbnail : `https://localhost:5001/api/CarImages/image/get?imageName=${activeThumbnail}`}
                    alt="active__Thumbnail"
                    height="100%"
                    width="100%"
                />
            </div>
        )
    }
}

const styles = {
    height: 'auto',
    width: '100%',
    background: '#333'
}

export default ActiveThumbnailWindow