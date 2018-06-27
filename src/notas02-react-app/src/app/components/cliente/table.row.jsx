import React from 'react'

export default ({ data }) => (
    <tr>
        <td>{data.id}</td>
        <td>{data.nome}</td>
        <td>
            <button className="btn btn-outline-primary">
                <i className="fas fa-edit"></i>
            </button>
            {' '}
            <button className="btn btn-outline-danger">
                <i className="fas fa-times"></i>
            </button>
        </td>
    </tr>
)