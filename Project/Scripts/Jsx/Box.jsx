var Box = React.createClass({
    getDefaultProps: function () {
        return {
            data: {
                Title: "",
                Rate: "",
                Comments: "",
                Url: "",
                Id: ""
            }
        };
    },
    getInitialState: function () {
        return { isRated: false };
    },

    onClick: function()
    {
        this.setState({ isRated: true });
    },
    render: function () {

        var img = null;

        if (this.props.data.Type === 1) {
            img = <img src={this.props.data.Url} style={{}} className="w3-margin-bottom width-100" />;
        }
        var comments = null;
        if (this.props.data.Comments) {
            comments = (<div className="w3-panel w3-topbar w3-bottombar comments">
                    <p>
                        {this.props.data.Comments}
                    </p>
            </div>);
        }
        var rateClassName = "fa fa-thumbs-o-up";
        if (this.state.isRated)
        {
            rateClassName = "fa fa-thumbs-up";
        }

        return (
        <div className="w3-container w3-card-2 w3-white w3-round w3-margin min-height">
          <br />
            <img src="Content/Images/Logo.jpg" alt="Avatar" className="w3-left w3-circle w3-margin-right" style={{width: 60}} />
              <h4>高能楼主</h4><br />
              <hr className="w3-clear" />
                <p>{this.props.data.Title}</p>
            {img}
            {comments}
                  <button type="button" className="w3-btn w3-theme-d1 w3-margin-bottom" onClick={this.onClick}><i className={rateClassName}></i> {this.props.data.Rate} </button>
        </div>
    );
    }
});