import React from 'react'

export default ({ searchTitle, searchText, handleSearch, handleSearchTextChanged }) => {

    const onChangeFilterText = (e) => {
        if (handleSearchTextChanged) handleSearchTextChanged(e.target.value)
    }

    return (
        <div className="container-fluid">
            <div className="card">
                <div className="card-header">
                    <h5>{searchTitle}</h5>
                </div>
                <div className="card-body">
                    <div className="input-group mb-3">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Enter your text filter"
                            value={searchText}
                            onChange={onChangeFilterText} />
                        <div className="input-group-append">
                            <button
                                className="btn btn-outline-primary"
                                type="button"
                                onClick={handleSearch}
                            >Search</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}