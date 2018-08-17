import React from 'react'

export default ({ title, id, name, type, value, validMessage, invalidMessage, onChange }) => {

    const onBlur = (e) => {
        if (!e.target.value) {
            e.target.classList.add('is-invalid')
            e.target.classList.remove('is-valid')
        } else {
            e.target.classList.add('is-valid')
            e.target.classList.remove('is-invalid')
        }
    }

    return (
        <div className="form-row">
            <div className="col-md-4 mb-3">
                <label htmlFor={id}>{title}</label>
                <input
                    type={type}
                    className='form-control'
                    id={id}
                    name={name}
                    onBlur={onBlur}
                    onChange={onChange}
                    value={value}
                />
                <div className="valid-feedback">
                    {validMessage}
                </div>
                <div className="invalid-feedback">
                    {invalidMessage}
                </div>
            </div>
        </div>
    )
}