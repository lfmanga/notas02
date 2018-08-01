import React from 'react'

export default ({ title, id, name, type }) => (
    <div className="form-group">
        <label htmlFor={id}>{title}</label>
        <input
            id={id}
            name={name}
            type={type}
            className="form-control"
        />
    </div>
)