import React from 'react'

export default ({ list, handleEdit, handleRemove }) => {

    const onClickEdit = (id) => {
        if (handleEdit) handleEdit(id)
    }

    const onClickRemove = (id) => {
        if (handleRemove) handleRemove(id)
    }

    return (
        <table className="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Nome</th>
                    <th>
                        <button
                            className="btn btn-outline-primary w-25"
                            onClick={() => onClickEdit()} >
                            <i className="fas fa-plus"></i>
                        </button>
                    </th>
                </tr>
            </thead>
            <tbody>
                {
                    list.map((v) => {
                        return (
                            <tr key={v.id}>
                                <td>{v.id}</td>
                                <td>{v.nome}</td>
                                <td>
                                    <button
                                        className="btn btn-outline-primary w-25"
                                        onClick={() => onClickEdit(v.id)} >
                                        <i className="fas fa-edit"></i>
                                    </button>
                                    {' '}
                                    <button
                                        className="btn btn-outline-danger w-25"
                                        onClick={() => onClickRemove(v.id)}>
                                        <i className="fas fa-times"></i>
                                    </button>
                                </td>
                            </tr>
                        )
                    })
                }
            </tbody>
        </table>
    )
}