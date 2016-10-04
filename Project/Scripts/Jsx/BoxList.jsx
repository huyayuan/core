var BoxList = React.createClass({
    getInitialState: function () {
        return { boxList: [] };
    },
    componentDidMount: function () {
        $.ajax({
            url: "home/getdata", success: function (data) {
                this.setState({ boxList: data });
            }.bind(this)
        });
    },
    onClick: function () {
        this.setState({ boxList: [] });
        $.ajax({
            url: "home/getdata", success: function (data) {
                this.setState({ boxList: data });
            }.bind(this)
        });
    },
    render: function () {
        var boxList = _.map(this.state.boxList, function (box) {
            return <Box key={box.Id} data={box} />
        });
        return (
	<div>
	    {boxList}
        <div id="change-content" className="w3-container w3-card-2 w3-white w3-round">
             <button onClick={this.onClick} className="w3-btn w3-white text-center">换一批</button>
        </div>
	</div>
    );
    }
});
ReactDOM.render(
  <BoxList />,
  document.getElementById('content')
);