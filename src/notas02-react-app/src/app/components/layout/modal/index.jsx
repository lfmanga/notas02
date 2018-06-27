import React from 'react'
import { Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap'

export default ({ isOpen, handleToggle, titleText, buttonSaveText, buttonCancelText, children }) => (
    <div>
        <Modal isOpen={isOpen} toggle={handleToggle}>
            <ModalHeader toggle={handleToggle}>{titleText}</ModalHeader>
            <ModalBody>
                {children ? children : 'No Modal Body Found'}
            </ModalBody>
            <ModalFooter>
                <button className="btn btn-outline-success">{buttonSaveText}</button>{' '}
                <button className="btn btn-outline-danger">{buttonCancelText}</button>
            </ModalFooter>
        </Modal>
    </div>
)