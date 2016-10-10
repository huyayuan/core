var BoxList = React.createClass({
    getInitialState: function () {
        return { boxList: [], index: 0};
    },
    componentDidMount: function () {
        $.ajax({
            url: "home/getdata?index=0", success: function (data) {
                this.setState({ boxList: data });
            }.bind(this)
        });
    },
    onClick: function () {
        this.setState({ boxList: [] });
        var index = this.state.index + 1;
        $.ajax({
            url: "home/getdata?index=" + index, success: function (data) {
                this.setState({ boxList: data, index });
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
             <button onClick={this.onClick} className="w3-btn w3-white text-center"><i className="fa fa-wheelchair-alt"></i> <span className="button-word">传送</span> </button>
        </div>
	</div>
    );
    }
});
ReactDOM.render(
  <BoxList />,
  document.getElementById('content')
);