(self["webpackChunkignitevms_client"] = self["webpackChunkignitevms_client"] || []).push([["ivms-example"],{

/***/ "./pages/Example/index.js":
/*!********************************!*\
  !*** ./pages/Example/index.js ***!
  \********************************/
/*! namespace exports */
/*! export default [provided] [no usage info] [missing usage info prevents renaming] */
/*! other exports [not provided] [no usage info] */
/*! runtime requirements: __webpack_require__, __webpack_exports__, __webpack_require__.r, __webpack_require__.d, __webpack_require__.* */
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": () => __WEBPACK_DEFAULT_EXPORT__
/* harmony export */ });
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react_redux__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react-redux */ "./node_modules/react-redux/es/index.js");
/* harmony import */ var _modules_actions__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./modules/actions */ "./pages/Example/modules/actions.js");
/* harmony import */ var _modules_selectors__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./modules/selectors */ "./pages/Example/modules/selectors.js");
;




var ExamplePage = function ExamplePage(props) {
  var init = props.init,
      result = props.result;
  (0,react__WEBPACK_IMPORTED_MODULE_0__.useEffect)(function () {
    init();
  }, []);
  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("div", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h1", null, "Hello World!"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h2", null, "This is an example page with some documentation."), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, "This page will be removed soon and the route will be replaced by the dashboard page."), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("hr", null), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("article", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h3", null, "Useful videos"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("ul", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("a", {
    href: "https://www.youtube.com/watch?v=GU-2T7k9NfI&ab_channel=Academind",
    target: "_blank",
    rel: "noopener noreferrer"
  }, "What is webpack?")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("a", {
    href: "https://www.youtube.com/watch?v=CVpUuw9XSjY&ab_channel=DevEd",
    target: "_blank",
    rel: "noopener noreferrer"
  }, "React Redux Tutorial")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("a", {
    href: "https://www.youtube.com/watch?v=eUMbH6X_Adc&ab_channel=techsith",
    target: "_blank",
    rel: "noopener noreferrer"
  }, "Redux Saga Tutorial")))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("article", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h3", null, "Useful Routes"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("ul", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("a", {
    href: "/swagger"
  }, "/swagger"), ": Route for the auto-generated swagger documentation. As we build the API, this page will get updated with information for it."))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("article", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h3", null, "Folder Structure"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("ul", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/app:"), " This is where the global layout, reducers, sagas, actions, routing and other all-encompasing things live.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/pages:"), " This is where the pages live, along with their own reducers, sagas and actions. They can also contain page-specific components.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/components:"), " This is where shared components live. A Loader component is a good example because it could be used on many different pages.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/assets:"), " Here we can put any local assets such as image files. Might not be used")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/util:"), " Files containing utility methods, constants or other useful files such as the bootstrap theme override files.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/webpack:"), " Configuration files for webpack. Used to build our code. The work here is done.")))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("article", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h3", null, "\"modules\" folders"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, "You'll find these folders under ", /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "/app"), " and under each page directory that requires them. These folders typically contain 3 files: actions.js, sagas.js and reducers.js. ", /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("br", null), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("ul", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "actions.js"), " contains action definitions. Actions are \"dispatched\" to modify the redux state using reducers or trigger sagas.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "reducer.js"), " specifies the way that actions modify state, and also set the initial state for a \"section\" of the redux state.")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("li", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("p", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("strong", null, "sagas.js"), " contains generator functions that are triggered by actions. You'll generally use these for api calls and to interact the redux state."))))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("article", null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("h3", null, "Result from the example Volunteers API endpoint"), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0__.createElement("pre", null, result)));
};

/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = ((0,react_redux__WEBPACK_IMPORTED_MODULE_1__.connect)(function (state) {
  return {
    result: _modules_selectors__WEBPACK_IMPORTED_MODULE_3__.default.selectExampleResult(state)
  };
}, {
  init: _modules_actions__WEBPACK_IMPORTED_MODULE_2__.initialize
})(ExamplePage));

/***/ }),

/***/ "./pages/Example/modules/selectors.js":
/*!********************************************!*\
  !*** ./pages/Example/modules/selectors.js ***!
  \********************************************/
/*! namespace exports */
/*! export default [provided] [no usage info] [missing usage info prevents renaming] */
/*! other exports [not provided] [no usage info] */
/*! runtime requirements: __webpack_require__, __webpack_exports__, __webpack_require__.r, __webpack_require__.d, __webpack_require__.* */
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": () => __WEBPACK_DEFAULT_EXPORT__
/* harmony export */ });
/* harmony import */ var pages_selectors__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! pages/selectors */ "./pages/selectors.js");
;
var selectors = (0,pages_selectors__WEBPACK_IMPORTED_MODULE_0__.createSelectors)({
  selectExampleResult: function selectExampleResult(state) {
    return selectors.selectPageState(state, 'example').testMessage;
  }
});
/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = (selectors);

/***/ })

}]);
//# sourceMappingURL=ivms-example_c968f340ca1e6d9e66d2.module.js.map