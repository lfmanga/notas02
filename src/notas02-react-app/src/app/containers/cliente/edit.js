import React from 'react'
import { AuthHttpClient } from '../../auth'

import EditComponent from '../../components/cliente/edit'

const defaultState = {
    id: undefined,
    data: {},
    showModal: false
}

class Edit extends React.Component {

    constructor(props) {
        super(props)
        this.state = defaultState
    }

    componentWillReceiveProps(nextProps) {
        this.setState({
            showModal: nextProps.showModal,
            id: nextProps.id
        }, _ => {
            let self = this
            let url = self.props.apiUrl + '/' + self.state.id
            AuthHttpClient()
                .get(url)
                .then(response => {
                    if (response.status === 200) {
                        let data = response.data
                        self.setState({ data })
                    }
                })
        })
    }

    handleModal() {
        let showModal = !this.state.showModal
        this.setState({ showModal })
    }

    handleChange(e) {
        let data = this.state.data
        data[e.target.name] = e.target.value
        this.setState({ data })
    }

    handleSave() {
        let self = this
        if (this.state.id) {
            let url = self.props.apiUrl + '/' + this.state.id
            AuthHttpClient()
                .put(url, this.state.data)
                .then(res => {
                    this.setState({
                        showModal: false,
                        data: {}
                    })
                    this.props.refList.reload()
                })
        } else {
            AuthHttpClient()
                .post(self.props.apiUrl, this.state.data)
                .then(res => {
                    this.setState({
                        showModal: false,
                        data: {}
                    })
                    this.props.refList.reload()
                })
        }
    }

    render() {
        return (
            <EditComponent
                showModal={this.state.showModal}
                handleModal={this.handleModal.bind(this)}

                data={this.state.data}
                handleChange={this.handleChange.bind(this)}

                handleSave={this.handleSave.bind(this)}
                handleCancel={this.handleModal.bind(this)}
            />
        )
    }
}

export default Edit