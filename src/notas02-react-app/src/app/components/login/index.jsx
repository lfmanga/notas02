import React from 'react'
import TextBox from '../../components/forms/TextBox'

export default ({ state, onChange, onSubmit }) => {

    return (
        <div className="container">
            <form className="needs-validation" onSubmit={onSubmit} noValidate>
                <TextBox
                    title={'Email'}
                    id={'email'}
                    name={'email'}
                    type={'text'}
                    validMessage={':D'}
                    invalidMessage={'Required'}
                    change={onChange}
                />
                <TextBox
                    title={'Senha'}
                    id={'senha'}
                    name={'senha'}
                    type={'password'}
                    validMessage={':D'}
                    invalidMessage={'Required'}
                    change={onChange}
                />
                <button
                    type="submit"
                    className="btn btn-primary"
                >Login</button>
            </form>
        </div>
    )
}