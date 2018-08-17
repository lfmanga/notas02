import React from 'react'

export default () => {

    return (
        <div className="input-group mb-3">
            <input
                type="text"
                className="form-control"
                 />
            <div className="input-group-append">
                <button
                    className="btn btn-outline-primary"
                    type="button"
                >Buscar</button>
            </div>
        </div>
    )
}