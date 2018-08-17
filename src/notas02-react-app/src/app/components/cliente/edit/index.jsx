import React from 'react'
import { Modal, ModalHeader, ModalBody } from 'reactstrap'

export default ({ showModal, handleModal,  data, handleChange, handleSave, handleCancel }) => {

    const onSave = (e) => {
        e.preventDefault()
        if (handleSave) handleSave()
    }

    const onCancel = (e) => {
        e.preventDefault()
        if (handleCancel) handleCancel()
    }

    return (
        <div>
            <Modal isOpen={showModal}>
                <ModalHeader toggle={handleModal}>Manager</ModalHeader>
                <ModalBody>
                    <form>
                        <div className="form-group">
                            <label htmlFor="clienteId">Id</label>
                            <input
                                type="text"
                                className="form-control"
                                id="clienteId"
                                defaultValue={data.id}
                                value={data.id}
                                disabled
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="clienteNome">Nome</label>
                            <input
                                type="text"
                                className="form-control"
                                id="clienteNome"
                                name="nome"
                                value={data.nome}
                                onChange={handleChange}
                            />
                        </div>
                        <button
                            type="button"
                            className="btn btn-outline-success"
                            onClick={onSave}
                        >Save</button>{' '}
                        <button
                            type="button"
                            className="btn btn-outline-danger"
                            onClick={onCancel}
                        >Cancel</button>
                    </form>
                </ModalBody>
            </Modal>
        </div>
    )
}