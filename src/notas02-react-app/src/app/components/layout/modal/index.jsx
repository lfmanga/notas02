import React from 'react'
import { Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap'

export default (
    { isOpen
        , handleToggle
        , titleText
        , buttonSaveText
        , handleButtonSave
        , buttonCancelText
        , handleButtonCancel
        , children }) => (
        <div>
            <Modal isOpen={isOpen} toggle={handleToggle}>
                <ModalHeader toggle={handleToggle}>{titleText}</ModalHeader>
                <ModalBody>
                    {children ? children : 'No Modal Body Found'}
                </ModalBody>
                <ModalFooter>
                    <button 
                        className="btn btn-outline-success"
                        onClick={handleButtonSave}
                    >
                    {buttonSaveText}</button>{' '}
                    <button 
                        className="btn btn-outline-danger"
                        onClick={handleButtonCancel}
                    >
                    {buttonCancelText}</button>
                </ModalFooter>
            </Modal>
        </div>
    )