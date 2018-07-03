import React from 'react'
import Modal from '../layout/modal'

export default ({
    data,
    isOpen,
    handleButtonSave,
    handleButtonCancel,
    handleTextChanged
}) => (
        <Modal
            isOpen={isOpen}
            handleToggle={() => (console.log(arguments))}
            titleText={'Manager'}
            buttonSaveText={'Save'}
            handleButtonSave={handleButtonSave}
            buttonCancelText={'Cancel'}
            handleButtonCancel={handleButtonCancel}
        >
            <form>
                <div className="form-group">
                    <label htmlFor="clienteId">Id</label>
                    <input
                        type="text"
                        className="form-control"
                        id="clienteId"
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
                        onChange={handleTextChanged}
                    />
                </div>
            </form>
        </Modal>
    )