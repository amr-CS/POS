﻿/*! jsTree - v3.3.7 - 2018-11-14 - (MIT) */

! function (e) {
    "use strict";
    "function" == typeof define && define.amd ? define(["jquery"], e) : "undefined" != typeof module && module.exports ? module.exports = e(require("jquery")) : e(jQuery)
}(function (S, E) {
    "use strict";
    if (!S.jstree) {
        var s = 0,
            a = !1,
            n = !1,
            o = !1,
            r = [],
            e = S("script:last").attr("src"),
            k = window.document;
        S.jstree = {
            version: "3.3.7",
            defaults: {
                plugins: []
            },
            plugins: {},
            path: e && -1 !== e.indexOf("/") ? e.replace(/\/[^\/]+$/, "") : "",
            idregex: /[\\:&!^|()\[\]<>@*'+~#";.,=\- \/${}%?`]/g,
            root: "#"
        }, S.jstree.create = function (e, i) {
            var r = new S.jstree.core(++s),
                t = i;
            return i = S.extend(!0, {}, S.jstree.defaults, i), t && t.plugins && (i.plugins = t.plugins), S.each(i.plugins, function (e, t) {
                "core" !== e && (r = r.plugin(t, i[t]))
            }), S(e).data("jstree", r), r.init(e, i), r
        }, S.jstree.destroy = function () {
            S(".jstree:jstree").jstree("destroy"), S(k).off(".jstree")
        }, S.jstree.core = function (e) {
            this._id = e, this._cnt = 0, this._wrk = null, this._data = {
                core: {
                    themes: {
                        name: !1,
                        dots: !1,
                        icons: !1,
                        ellipsis: !1
                    },
                    selected: [],
                    last_error: {},
                    working: !1,
                    worker_queue: [],
                    focused: null
                }
            }
        }, S.jstree.reference = function (t) {
            var i = null,
                e = null;
            if (!t || !t.id || t.tagName && t.nodeType || (t = t.id), !e || !e.length) try {
                e = S(t)
            } catch (e) { }
            if (!e || !e.length) try {
                e = S("#" + t.replace(S.jstree.idregex, "\\$&"))
            } catch (e) { }
            return e && e.length && (e = e.closest(".jstree")).length && (e = e.data("jstree")) ? i = e : S(".jstree").each(function () {
                var e = S(this).data("jstree");
                if (e && e._model.data[t]) return i = e, !1
            }), i
        }, S.fn.jstree = function (i) {
            var r = "string" == typeof i,
                s = Array.prototype.slice.call(arguments, 1),
                a = null;
            return !(!0 === i && !this.length) && (this.each(function () {
                var e = S.jstree.reference(this),
                    t = r && e ? e[i] : null;
                if (a = r && t ? t.apply(e, s) : null, e || r || i !== E && !S.isPlainObject(i) || S.jstree.create(this, i), (e && !r || !0 === i) && (a = e || !1), null !== a && a !== E) return !1
            }), null !== a && a !== E ? a : this)
        }, S.expr.pseudos.jstree = S.expr.createPseudo(function (e) {
            return function (e) {
                return S(e).hasClass("jstree") && S(e).data("jstree") !== E
            }
        }), S.jstree.defaults.core = {
            data: !1,
            strings: !1,
            check_callback: !1,
            error: S.noop,
            animation: 200,
            multiple: !0,
            themes: {
                name: !1,
                url: !1,
                dir: !1,
                dots: !0,
                icons: !0,
                ellipsis: !1,
                stripes: !1,
                variant: !1,
                responsive: !1
            },
            expand_selected_onload: !0,
            worker: !0,
            force_text: !1,
            dblclick_toggle: !0,
            loaded_state: !1,
            restore_focus: !0,
            keyboard: {
                "ctrl-space": function (e) {
                    e.type = "click", S(e.currentTarget).trigger(e)
                },
                enter: function (e) {
                    e.type = "click", S(e.currentTarget).trigger(e)
                },
                left: function (e) {
                    if (e.preventDefault(), this.is_open(e.currentTarget)) this.close_node(e.currentTarget);
                    else {
                        var t = this.get_parent(e.currentTarget);
                        t && t.id !== S.jstree.root && this.get_node(t, !0).children(".jstree-anchor").focus()
                    }
                },
                up: function (e) {
                    e.preventDefault();
                    var t = this.get_prev_dom(e.currentTarget);
                    t && t.length && t.children(".jstree-anchor").focus()
                },
                right: function (e) {
                    if (e.preventDefault(), this.is_closed(e.currentTarget)) this.open_node(e.currentTarget, function (e) {
                        this.get_node(e, !0).children(".jstree-anchor").focus()
                    });
                    else if (this.is_open(e.currentTarget)) {
                        var t = this.get_node(e.currentTarget, !0).children(".jstree-children")[0];
                        t && S(this._firstChild(t)).children(".jstree-anchor").focus()
                    }
                },
                down: function (e) {
                    e.preventDefault();
                    var t = this.get_next_dom(e.currentTarget);
                    t && t.length && t.children(".jstree-anchor").focus()
                },
                "*": function (e) {
                    this.open_all()
                },
                home: function (e) {
                    e.preventDefault();
                    var t = this._firstChild(this.get_container_ul()[0]);
                    t && S(t).children(".jstree-anchor").filter(":visible").focus()
                },
                end: function (e) {
                    e.preventDefault(), this.element.find(".jstree-anchor").filter(":visible").last().focus()
                },
                f2: function (e) {
                    e.preventDefault(), this.edit(e.currentTarget)
                }
            }
        }, S.jstree.core.prototype = {
            plugin: function (e, t) {
                var i = S.jstree.plugins[e];
                return i ? (this._data[e] = {}, i.prototype = this, new i(t, this)) : this
            },
            init: function (e, t) {
                this._model = {
                    data: {},
                    changed: [],
                    force_full_redraw: !1,
                    redraw_timeout: !1,
                    default_state: {
                        loaded: !0,
                        opened: !1,
                        selected: !1,
                        disabled: !1
                    }
                }, this._model.data[S.jstree.root] = {
                    id: S.jstree.root,
                    parent: null,
                    parents: [],
                    children: [],
                    children_d: [],
                    state: {
                        loaded: !1
                    }
                }, this.element = S(e).addClass("jstree jstree-" + this._id), this.settings = t, this._data.core.ready = !1, this._data.core.loaded = !1, this._data.core.rtl = "rtl" === this.element.css("direction"), this.element[this._data.core.rtl ? "addClass" : "removeClass"]("jstree-rtl"), this.element.attr("role", "tree"), this.settings.core.multiple && this.element.attr("aria-multiselectable", !0), this.element.attr("tabindex") || this.element.attr("tabindex", "0"), this.bind(), this.trigger("init"), this._data.core.original_container_html = this.element.find(" > ul > li").clone(!0), this._data.core.original_container_html.find("li").addBack().contents().filter(function () {
                    return 3 === this.nodeType && (!this.nodeValue || /^\s+$/.test(this.nodeValue))
                }).remove(), this.element.html("<ul class='jstree-container-ul jstree-children' role='group'><li id='j" + this._id + "_loading' class='jstree-initial-node jstree-loading jstree-leaf jstree-last' role='tree-item'><i class='jstree-icon jstree-ocl'></i><a class='jstree-anchor' href='#'><i class='jstree-icon jstree-themeicon-hidden'></i>" + this.get_string("Loading ...") + "</a></li></ul>"), this.element.attr("aria-activedescendant", "j" + this._id + "_loading"), this._data.core.li_height = this.get_container_ul().children("li").first().outerHeight() || 24, this._data.core.node = this._create_prototype_node(), this.trigger("loading"), this.load_node(S.jstree.root)
            },
            destroy: function (e) {
                if (this.trigger("destroy"), this._wrk) try {
                    window.URL.revokeObjectURL(this._wrk), this._wrk = null
                } catch (e) { }
                e || this.element.empty(), this.teardown()
            },
            _create_prototype_node: function () {
                var e = k.createElement("LI"),
                    t, i;
                return e.setAttribute("role", "treeitem"), (t = k.createElement("I")).className = "jstree-icon jstree-ocl", t.setAttribute("role", "presentation"), e.appendChild(t), (t = k.createElement("A")).className = "jstree-anchor", t.setAttribute("href", "#"), t.setAttribute("tabindex", "-1"), (i = k.createElement("I")).className = "jstree-icon jstree-themeicon", i.setAttribute("role", "presentation"), t.appendChild(i), e.appendChild(t), t = i = null, e
            },
            _kbevent_to_func: function (e) {
                var t = {
                    8: "Backspace",
                    9: "Tab",
                    13: "Return",
                    19: "Pause",
                    27: "Esc",
                    32: "Space",
                    33: "PageUp",
                    34: "PageDown",
                    35: "End",
                    36: "Home",
                    37: "Left",
                    38: "Up",
                    39: "Right",
                    40: "Down",
                    44: "Print",
                    45: "Insert",
                    46: "Delete",
                    96: "Numpad0",
                    97: "Numpad1",
                    98: "Numpad2",
                    99: "Numpad3",
                    100: "Numpad4",
                    101: "Numpad5",
                    102: "Numpad6",
                    103: "Numpad7",
                    104: "Numpad8",
                    105: "Numpad9",
                    "-13": "NumpadEnter",
                    112: "F1",
                    113: "F2",
                    114: "F3",
                    115: "F4",
                    116: "F5",
                    117: "F6",
                    118: "F7",
                    119: "F8",
                    120: "F9",
                    121: "F10",
                    122: "F11",
                    123: "F12",
                    144: "Numlock",
                    145: "Scrolllock",
                    16: "Shift",
                    17: "Ctrl",
                    18: "Alt",
                    48: "0",
                    49: "1",
                    50: "2",
                    51: "3",
                    52: "4",
                    53: "5",
                    54: "6",
                    55: "7",
                    56: "8",
                    57: "9",
                    59: ";",
                    61: "=",
                    65: "a",
                    66: "b",
                    67: "c",
                    68: "d",
                    69: "e",
                    70: "f",
                    71: "g",
                    72: "h",
                    73: "i",
                    74: "j",
                    75: "k",
                    76: "l",
                    77: "m",
                    78: "n",
                    79: "o",
                    80: "p",
                    81: "q",
                    82: "r",
                    83: "s",
                    84: "t",
                    85: "u",
                    86: "v",
                    87: "w",
                    88: "x",
                    89: "y",
                    90: "z",
                    107: "+",
                    109: "-",
                    110: ".",
                    186: ";",
                    187: "=",
                    188: ",",
                    189: "-",
                    190: ".",
                    191: "/",
                    192: "`",
                    219: "[",
                    220: "\\",
                    221: "]",
                    222: "'",
                    111: "/",
                    106: "*",
                    173: "-"
                },
                    i = [];
                e.ctrlKey && i.push("ctrl"), e.altKey && i.push("alt"), e.shiftKey && i.push("shift"), i.push(t[e.which] || e.which), i = i.sort().join("-").toLowerCase();
                var r = this.settings.core.keyboard,
                    s, a;
                for (s in r)
                    if (r.hasOwnProperty(s) && ("-" !== (a = s) && "+" !== a && (a = (a = a.replace("--", "-MINUS").replace("+-", "-MINUS").replace("++", "-PLUS").replace("-+", "-PLUS")).split(/-|\+/).sort().join("-").replace("MINUS", "-").replace("PLUS", "+").toLowerCase()), a === i)) return r[s];
                return null
            },
            teardown: function () {
                this.unbind(), this.element.removeClass("jstree").removeData("jstree").find("[class^='jstree']").addBack().attr("class", function () {
                    return this.className.replace(/jstree[^ ]*|$/gi, "")
                }), this.element = null
            },
            bind: function () {
                var a = "",
                    n = null,
                    t = 0;
                this.element.on("dblclick.jstree", function (e) {
                    if (e.target.tagName && "input" === e.target.tagName.toLowerCase()) return !0;
                    if (k.selection && k.selection.empty) k.selection.empty();
                    else if (window.getSelection) {
                        var t = window.getSelection();
                        try {
                            t.removeAllRanges(), t.collapse()
                        } catch (e) { }
                    }
                }).on("mousedown.jstree", S.proxy(function (e) {
                    e.target === this.element[0] && (e.preventDefault(), t = +new Date)
                }, this)).on("mousedown.jstree", ".jstree-ocl", function (e) {
                    e.preventDefault()
                }).on("click.jstree", ".jstree-ocl", S.proxy(function (e) {
                    this.toggle_node(e.target)
                }, this)).on("dblclick.jstree", ".jstree-anchor", S.proxy(function (e) {
                    if (e.target.tagName && "input" === e.target.tagName.toLowerCase()) return !0;
                    this.settings.core.dblclick_toggle && this.toggle_node(e.target)
                }, this)).on("click.jstree", ".jstree-anchor", S.proxy(function (e) {
                    e.preventDefault(), e.currentTarget !== k.activeElement && S(e.currentTarget).focus(), this.activate_node(e.currentTarget, e)
                }, this)).on("keydown.jstree", ".jstree-anchor", S.proxy(function (e) {
                    if (e.target.tagName && "input" === e.target.tagName.toLowerCase()) return !0;
                    this._data.core.rtl && (37 === e.which ? e.which = 39 : 39 === e.which && (e.which = 37));
                    var t = this._kbevent_to_func(e);
                    if (t) {
                        var i = t.call(this, e);
                        if (!1 === i || !0 === i) return i
                    }
                }, this)).on("load_node.jstree", S.proxy(function (e, t) {
                    t.status && (t.node.id !== S.jstree.root || this._data.core.loaded || (this._data.core.loaded = !0, this._firstChild(this.get_container_ul()[0]) && this.element.attr("aria-activedescendant", this._firstChild(this.get_container_ul()[0]).id), this.trigger("loaded")), this._data.core.ready || setTimeout(S.proxy(function () {
                        if (this.element && !this.get_container_ul().find(".jstree-loading").length) {
                            if (this._data.core.ready = !0, this._data.core.selected.length) {
                                if (this.settings.core.expand_selected_onload) {
                                    var e = [],
                                        t, i;
                                    for (t = 0, i = this._data.core.selected.length; t < i; t++) e = e.concat(this._model.data[this._data.core.selected[t]].parents);
                                    for (t = 0, i = (e = S.vakata.array_unique(e)).length; t < i; t++) this.open_node(e[t], !1, 0)
                                }
                                this.trigger("changed", {
                                    action: "ready",
                                    selected: this._data.core.selected
                                })
                            }
                            this.trigger("ready")
                        }
                    }, this), 0))
                }, this)).on("keypress.jstree", S.proxy(function (e) {
                    if (e.target.tagName && "input" === e.target.tagName.toLowerCase()) return !0;
                    n && clearTimeout(n), n = setTimeout(function () {
                        a = ""
                    }, 500);
                    var i = String.fromCharCode(e.which).toLowerCase(),
                        t = this.element.find(".jstree-anchor").filter(":visible"),
                        r = t.index(k.activeElement) || 0,
                        s = !1;
                    if (1 < (a += i).length) {
                        if (t.slice(r).each(S.proxy(function (e, t) {
                            if (0 === S(t).text().toLowerCase().indexOf(a)) return S(t).focus(), !(s = !0)
                        }, this)), s) return;
                        if (t.slice(0, r).each(S.proxy(function (e, t) {
                            if (0 === S(t).text().toLowerCase().indexOf(a)) return S(t).focus(), !(s = !0)
                        }, this)), s) return
                    }
                    if (new RegExp("^" + i.replace(/[-\/\\^$*+?.()|[\]{}]/g, "\\$&") + "+$").test(a)) {
                        if (t.slice(r + 1).each(S.proxy(function (e, t) {
                            if (S(t).text().toLowerCase().charAt(0) === i) return S(t).focus(), !(s = !0)
                        }, this)), s) return;
                        if (t.slice(0, r + 1).each(S.proxy(function (e, t) {
                            if (S(t).text().toLowerCase().charAt(0) === i) return S(t).focus(), !(s = !0)
                        }, this)), s) return
                    }
                }, this)).on("init.jstree", S.proxy(function () {
                    var e = this.settings.core.themes;
                    this._data.core.themes.dots = e.dots, this._data.core.themes.stripes = e.stripes, this._data.core.themes.icons = e.icons, this._data.core.themes.ellipsis = e.ellipsis, this.set_theme(e.name || "default", e.url), this.set_theme_variant(e.variant)
                }, this)).on("loading.jstree", S.proxy(function () {
                    this[this._data.core.themes.dots ? "show_dots" : "hide_dots"](), this[this._data.core.themes.icons ? "show_icons" : "hide_icons"](), this[this._data.core.themes.stripes ? "show_stripes" : "hide_stripes"](), this[this._data.core.themes.ellipsis ? "show_ellipsis" : "hide_ellipsis"]()
                }, this)).on("blur.jstree", ".jstree-anchor", S.proxy(function (e) {
                    this._data.core.focused = null, S(e.currentTarget).filter(".jstree-hovered").mouseleave(), this.element.attr("tabindex", "0")
                }, this)).on("focus.jstree", ".jstree-anchor", S.proxy(function (e) {
                    var t = this.get_node(e.currentTarget);
                    t && t.id && (this._data.core.focused = t.id), this.element.find(".jstree-hovered").not(e.currentTarget).mouseleave(), S(e.currentTarget).mouseenter(), this.element.attr("tabindex", "-1")
                }, this)).on("focus.jstree", S.proxy(function () {
                    if (500 < +new Date - t && !this._data.core.focused && this.settings.core.restore_focus) {
                        t = 0;
                        var e = this.get_node(this.element.attr("aria-activedescendant"), !0);
                        e && e.find("> .jstree-anchor").focus()
                    }
                }, this)).on("mouseenter.jstree", ".jstree-anchor", S.proxy(function (e) {
                    this.hover_node(e.currentTarget)
                }, this)).on("mouseleave.jstree", ".jstree-anchor", S.proxy(function (e) {
                    this.dehover_node(e.currentTarget)
                }, this))
            },
            unbind: function () {
                this.element.off(".jstree"), S(k).off(".jstree-" + this._id)
            },
            trigger: function (e, t) {
                t || (t = {}), (t.instance = this).element.triggerHandler(e.replace(".jstree", "") + ".jstree", t)
            },
            get_container: function () {
                return this.element
            },
            get_container_ul: function () {
                return this.element.children(".jstree-children").first()
            },
            get_string: function (e) {
                var t = this.settings.core.strings;
                return S.isFunction(t) ? t.call(this, e) : t && t[e] ? t[e] : e
            },
            _firstChild: function (e) {
                e = e ? e.firstChild : null;
                while (null !== e && 1 !== e.nodeType) e = e.nextSibling;
                return e
            },
            _nextSibling: function (e) {
                e = e ? e.nextSibling : null;
                while (null !== e && 1 !== e.nodeType) e = e.nextSibling;
                return e
            },
            _previousSibling: function (e) {
                e = e ? e.previousSibling : null;
                while (null !== e && 1 !== e.nodeType) e = e.previousSibling;
                return e
            },
            get_node: function (e, t) {
                var i;
                e && e.id && (e = e.id), e instanceof S && e.length && e[0].id && (e = e[0].id);
                try {
                    if (this._model.data[e]) e = this._model.data[e];
                    else if ("string" == typeof e && this._model.data[e.replace(/^#/, "")]) e = this._model.data[e.replace(/^#/, "")];
                    else if ("string" == typeof e && (i = S("#" + e.replace(S.jstree.idregex, "\\$&"), this.element)).length && this._model.data[i.closest(".jstree-node").attr("id")]) e = this._model.data[i.closest(".jstree-node").attr("id")];
                    else if ((i = this.element.find(e)).length && this._model.data[i.closest(".jstree-node").attr("id")]) e = this._model.data[i.closest(".jstree-node").attr("id")];
                    else {
                        if (!(i = this.element.find(e)).length || !i.hasClass("jstree")) return !1;
                        e = this._model.data[S.jstree.root]
                    }
                    return t && (e = e.id === S.jstree.root ? this.element : S("#" + e.id.replace(S.jstree.idregex, "\\$&"), this.element)), e
                } catch (e) {
                    return !1
                }
            },
            get_path: function (e, t, i) {
                if (!(e = e.parents ? e : this.get_node(e)) || e.id === S.jstree.root || !e.parents) return !1;
                var r, s, a = [];
                for (a.push(i ? e.id : e.text), r = 0, s = e.parents.length; r < s; r++) a.push(i ? e.parents[r] : this.get_text(e.parents[r]));
                return a = a.reverse().slice(1), t ? a.join(t) : a
            },
            get_next_dom: function (e, t) {
                var i;
                if ((e = this.get_node(e, !0))[0] === this.element[0]) {
                    i = this._firstChild(this.get_container_ul()[0]);
                    while (i && 0 === i.offsetHeight) i = this._nextSibling(i);
                    return !!i && S(i)
                }
                if (!e || !e.length) return !1;
                if (t) {
                    i = e[0];
                    do {
                        i = this._nextSibling(i)
                    } while (i && 0 === i.offsetHeight);
                    return !!i && S(i)
                }
                if (e.hasClass("jstree-open")) {
                    i = this._firstChild(e.children(".jstree-children")[0]);
                    while (i && 0 === i.offsetHeight) i = this._nextSibling(i);
                    if (null !== i) return S(i)
                }
                i = e[0];
                do {
                    i = this._nextSibling(i)
                } while (i && 0 === i.offsetHeight);
                return null !== i ? S(i) : e.parentsUntil(".jstree", ".jstree-node").nextAll(".jstree-node:visible").first()
            },
            get_prev_dom: function (e, t) {
                var i;
                if ((e = this.get_node(e, !0))[0] === this.element[0]) {
                    i = this.get_container_ul()[0].lastChild;
                    while (i && 0 === i.offsetHeight) i = this._previousSibling(i);
                    return !!i && S(i)
                }
                if (!e || !e.length) return !1;
                if (t) {
                    i = e[0];
                    do {
                        i = this._previousSibling(i)
                    } while (i && 0 === i.offsetHeight);
                    return !!i && S(i)
                }
                i = e[0];
                do {
                    i = this._previousSibling(i)
                } while (i && 0 === i.offsetHeight);
                if (null === i) return !(!(i = e[0].parentNode.parentNode) || !i.className || -1 === i.className.indexOf("jstree-node")) && S(i);
                e = S(i);
                while (e.hasClass("jstree-open")) e = e.children(".jstree-children").first().children(".jstree-node:visible:last");
                return e
            },
            get_parent: function (e) {
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && e.parent
            },
            get_children_dom: function (e) {
                return (e = this.get_node(e, !0))[0] === this.element[0] ? this.get_container_ul().children(".jstree-node") : !(!e || !e.length) && e.children(".jstree-children").children(".jstree-node")
            },
            is_parent: function (e) {
                return (e = this.get_node(e)) && (!1 === e.state.loaded || 0 < e.children.length)
            },
            is_loaded: function (e) {
                return (e = this.get_node(e)) && e.state.loaded
            },
            is_loading: function (e) {
                return (e = this.get_node(e)) && e.state && e.state.loading
            },
            is_open: function (e) {
                return (e = this.get_node(e)) && e.state.opened
            },
            is_closed: function (e) {
                return (e = this.get_node(e)) && this.is_parent(e) && !e.state.opened
            },
            is_leaf: function (e) {
                return !this.is_parent(e)
            },
            load_node: function (n, o) {
                var e, t, i, r, s;
                if (S.isArray(n)) return this._load_nodes(n.slice(), o), !0;
                if (!(n = this.get_node(n))) return o && o.call(this, n, !1), !1;
                if (n.state.loaded) {
                    for (n.state.loaded = !1, i = 0, r = n.parents.length; i < r; i++) this._model.data[n.parents[i]].children_d = S.vakata.array_filter(this._model.data[n.parents[i]].children_d, function (e) {
                        return -1 === S.inArray(e, n.children_d)
                    });
                    for (e = 0, t = n.children_d.length; e < t; e++) this._model.data[n.children_d[e]].state.selected && (s = !0), delete this._model.data[n.children_d[e]];
                    s && (this._data.core.selected = S.vakata.array_filter(this._data.core.selected, function (e) {
                        return -1 === S.inArray(e, n.children_d)
                    })), n.children = [], n.children_d = [], s && this.trigger("changed", {
                        action: "load_node",
                        node: n,
                        selected: this._data.core.selected
                    })
                }
                return n.state.failed = !1, n.state.loading = !0, this.get_node(n, !0).addClass("jstree-loading").attr("aria-busy", !0), this._load_node(n, S.proxy(function (e) {
                    (n = this._model.data[n.id]).state.loading = !1, n.state.loaded = e, n.state.failed = !n.state.loaded;
                    var t = this.get_node(n, !0),
                        i = 0,
                        r = 0,
                        s = this._model.data,
                        a = !1;
                    for (i = 0, r = n.children.length; i < r; i++)
                        if (s[n.children[i]] && !s[n.children[i]].state.hidden) {
                            a = !0;
                            break
                        }
                    n.state.loaded && t && t.length && (t.removeClass("jstree-closed jstree-open jstree-leaf"), a ? "#" !== n.id && t.addClass(n.state.opened ? "jstree-open" : "jstree-closed") : t.addClass("jstree-leaf")), t.removeClass("jstree-loading").attr("aria-busy", !1), this.trigger("load_node", {
                        node: n,
                        status: e
                    }), o && o.call(this, n, e)
                }, this)), !0
            },
            _load_nodes: function (e, t, i, r) {
                var s = !0,
                    a = function () {
                        this._load_nodes(e, t, !0)
                    },
                    n = this._model.data,
                    o, d, c = [];
                for (o = 0, d = e.length; o < d; o++) n[e[o]] && (!n[e[o]].state.loaded && !n[e[o]].state.failed || !i && r) && (this.is_loading(e[o]) || this.load_node(e[o], a), s = !1);
                if (s) {
                    for (o = 0, d = e.length; o < d; o++) n[e[o]] && n[e[o]].state.loaded && c.push(e[o]);
                    t && !t.done && (t.call(this, c), t.done = !0)
                }
            },
            load_all: function (e, t) {
                if (e || (e = S.jstree.root), !(e = this.get_node(e))) return !1;
                var i = [],
                    r = this._model.data,
                    s = r[e.id].children_d,
                    a, n;
                for (e.state && !e.state.loaded && i.push(e.id), a = 0, n = s.length; a < n; a++) r[s[a]] && r[s[a]].state && !r[s[a]].state.loaded && i.push(s[a]);
                i.length ? this._load_nodes(i, function () {
                    this.load_all(e, t)
                }) : (t && t.call(this, e), this.trigger("load_all", {
                    node: e
                }))
            },
            _load_node: function (s, a) {
                var e = this.settings.core.data,
                    t, n = function e() {
                        return 3 !== this.nodeType && 8 !== this.nodeType
                    };
                return e ? S.isFunction(e) ? e.call(this, s, S.proxy(function (e) {
                    !1 === e ? a.call(this, !1) : this["string" == typeof e ? "_append_html_data" : "_append_json_data"](s, "string" == typeof e ? S(S.parseHTML(e)).filter(n) : e, function (e) {
                        a.call(this, e)
                    })
                }, this)) : "object" == typeof e ? e.url ? (e = S.extend(!0, {}, e), S.isFunction(e.url) && (e.url = e.url.call(this, s)), S.isFunction(e.data) && (e.data = e.data.call(this, s)), S.ajax(e).done(S.proxy(function (e, t, i) {
                    var r = i.getResponseHeader("Content-Type");
                    return r && -1 !== r.indexOf("json") || "object" == typeof e ? this._append_json_data(s, e, function (e) {
                        a.call(this, e)
                    }) : r && -1 !== r.indexOf("html") || "string" == typeof e ? this._append_html_data(s, S(S.parseHTML(e)).filter(n), function (e) {
                        a.call(this, e)
                    }) : (this._data.core.last_error = {
                        error: "ajax",
                        plugin: "core",
                        id: "core_04",
                        reason: "Could not load node",
                        data: JSON.stringify({
                            id: s.id,
                            xhr: i
                        })
                    }, this.settings.core.error.call(this, this._data.core.last_error), a.call(this, !1))
                }, this)).fail(S.proxy(function (e) {
                    this._data.core.last_error = {
                        error: "ajax",
                        plugin: "core",
                        id: "core_04",
                        reason: "Could not load node",
                        data: JSON.stringify({
                            id: s.id,
                            xhr: e
                        })
                    }, a.call(this, !1), this.settings.core.error.call(this, this._data.core.last_error)
                }, this))) : (t = S.isArray(e) ? S.extend(!0, [], e) : S.isPlainObject(e) ? S.extend(!0, {}, e) : e, s.id === S.jstree.root ? this._append_json_data(s, t, function (e) {
                    a.call(this, e)
                }) : (this._data.core.last_error = {
                    error: "nodata",
                    plugin: "core",
                    id: "core_05",
                    reason: "Could not load node",
                    data: JSON.stringify({
                        id: s.id
                    })
                }, this.settings.core.error.call(this, this._data.core.last_error), a.call(this, !1))) : "string" == typeof e ? s.id === S.jstree.root ? this._append_html_data(s, S(S.parseHTML(e)).filter(n), function (e) {
                    a.call(this, e)
                }) : (this._data.core.last_error = {
                    error: "nodata",
                    plugin: "core",
                    id: "core_06",
                    reason: "Could not load node",
                    data: JSON.stringify({
                        id: s.id
                    })
                }, this.settings.core.error.call(this, this._data.core.last_error), a.call(this, !1)) : a.call(this, !1) : s.id === S.jstree.root ? this._append_html_data(s, this._data.core.original_container_html.clone(!0), function (e) {
                    a.call(this, e)
                }) : a.call(this, !1)
            },
            _node_changed: function (e) {
                (e = this.get_node(e)) && -1 === S.inArray(e.id, this._model.changed) && this._model.changed.push(e.id)
            },
            _append_html_data: function (e, t, i) {
                (e = this.get_node(e)).children = [], e.children_d = [];
                var r = t.is("ul") ? t.children() : t,
                    s = e.id,
                    a = [],
                    n = [],
                    o = this._model.data,
                    d = o[s],
                    c = this._data.core.selected.length,
                    l, h, _;
                for (r.each(S.proxy(function (e, t) {
                    (l = this._parse_model_from_html(S(t), s, d.parents.concat())) && (a.push(l), n.push(l), o[l].children_d.length && (n = n.concat(o[l].children_d)))
                }, this)), d.children = a, d.children_d = n, h = 0, _ = d.parents.length; h < _; h++) o[d.parents[h]].children_d = o[d.parents[h]].children_d.concat(n);
                this.trigger("model", {
                    nodes: n,
                    parent: s
                }), s !== S.jstree.root ? (this._node_changed(s), this.redraw()) : (this.get_container_ul().children(".jstree-initial-node").remove(), this.redraw(!0)), this._data.core.selected.length !== c && this.trigger("changed", {
                    action: "model",
                    selected: this._data.core.selected
                }), i.call(this, !0)
            },
            _append_json_data: function (e, t, d, i) {
                if (null !== this.element) {
                    (e = this.get_node(e)).children = [], e.children_d = [], t.d && "string" == typeof (t = t.d) && (t = JSON.parse(t)), S.isArray(t) || (t = [t]);
                    var r = null,
                        s = {
                            df: this._model.default_state,
                            dat: t,
                            par: e.id,
                            m: this._model.data,
                            t_id: this._id,
                            t_cnt: this._cnt,
                            sel: this._data.core.selected
                        },
                        j = this,
                        a = function (e, c) {
                            e.data && (e = e.data);
                            var t = e.dat,
                                i = e.par,
                                r = [],
                                s = [],
                                l = [],
                                h = e.df,
                                _ = e.t_id,
                                u = e.t_cnt,
                                g = e.m,
                                a = g[i],
                                n = e.sel,
                                o, d, f, p, m = function (e, t, i) {
                                    i = i ? i.concat() : [], t && i.unshift(t);
                                    var r = e.id.toString(),
                                        s, a, n, o, d = {
                                            id: r,
                                            text: e.text || "",
                                            icon: e.icon === c || e.icon,
                                            parent: t,
                                            parents: i,
                                            children: e.children || [],
                                            children_d: e.children_d || [],
                                            data: e.data,
                                            state: {},
                                            li_attr: {
                                                id: !1
                                            },
                                            a_attr: {
                                                href: "#"
                                            },
                                            original: !1
                                        };
                                    for (s in h) h.hasOwnProperty(s) && (d.state[s] = h[s]);
                                    if (e && e.data && e.data.jstree && e.data.jstree.icon && (d.icon = e.data.jstree.icon), d.icon !== c && null !== d.icon && "" !== d.icon || (d.icon = !0), e && e.data && (d.data = e.data, e.data.jstree))
                                        for (s in e.data.jstree) e.data.jstree.hasOwnProperty(s) && (d.state[s] = e.data.jstree[s]);
                                    if (e && "object" == typeof e.state)
                                        for (s in e.state) e.state.hasOwnProperty(s) && (d.state[s] = e.state[s]);
                                    if (e && "object" == typeof e.li_attr)
                                        for (s in e.li_attr) e.li_attr.hasOwnProperty(s) && (d.li_attr[s] = e.li_attr[s]);
                                    if (d.li_attr.id || (d.li_attr.id = r), e && "object" == typeof e.a_attr)
                                        for (s in e.a_attr) e.a_attr.hasOwnProperty(s) && (d.a_attr[s] = e.a_attr[s]);
                                    for (e && e.children && !0 === e.children && (d.state.loaded = !1, d.children = [], d.children_d = []), s = 0, a = (g[d.id] = d).children.length; s < a; s++) n = m(g[d.children[s]], d.id, i), o = g[n], d.children_d.push(n), o.children_d.length && (d.children_d = d.children_d.concat(o.children_d));
                                    return delete e.data, delete e.children, g[d.id].original = e, d.state.selected && l.push(d.id), d.id
                                },
                                v = function (e, t, i) {
                                    i = i ? i.concat() : [], t && i.unshift(t);
                                    var r = !1,
                                        s, a, n, o, d;
                                    do {
                                        r = "j" + _ + "_" + ++u
                                    } while (g[r]);
                                    for (s in d = {
                                        id: !1,
                                        text: "string" == typeof e ? e : "",
                                        icon: "object" != typeof e || e.icon === c || e.icon,
                                        parent: t,
                                        parents: i,
                                        children: [],
                                        children_d: [],
                                        data: null,
                                        state: {},
                                        li_attr: {
                                            id: !1
                                        },
                                        a_attr: {
                                            href: "#"
                                        },
                                        original: !1
                                    }, h) h.hasOwnProperty(s) && (d.state[s] = h[s]);
                                    if (e && e.id && (d.id = e.id.toString()), e && e.text && (d.text = e.text), e && e.data && e.data.jstree && e.data.jstree.icon && (d.icon = e.data.jstree.icon), d.icon !== c && null !== d.icon && "" !== d.icon || (d.icon = !0), e && e.data && (d.data = e.data, e.data.jstree))
                                        for (s in e.data.jstree) e.data.jstree.hasOwnProperty(s) && (d.state[s] = e.data.jstree[s]);
                                    if (e && "object" == typeof e.state)
                                        for (s in e.state) e.state.hasOwnProperty(s) && (d.state[s] = e.state[s]);
                                    if (e && "object" == typeof e.li_attr)
                                        for (s in e.li_attr) e.li_attr.hasOwnProperty(s) && (d.li_attr[s] = e.li_attr[s]);
                                    if (d.li_attr.id && !d.id && (d.id = d.li_attr.id.toString()), d.id || (d.id = r), d.li_attr.id || (d.li_attr.id = d.id), e && "object" == typeof e.a_attr)
                                        for (s in e.a_attr) e.a_attr.hasOwnProperty(s) && (d.a_attr[s] = e.a_attr[s]);
                                    if (e && e.children && e.children.length) {
                                        for (s = 0, a = e.children.length; s < a; s++) n = v(e.children[s], d.id, i), o = g[n], d.children.push(n), o.children_d.length && (d.children_d = d.children_d.concat(o.children_d));
                                        d.children_d = d.children_d.concat(d.children)
                                    }
                                    return e && e.children && !0 === e.children && (d.state.loaded = !1, d.children = [], d.children_d = []), delete e.data, delete e.children, d.original = e, (g[d.id] = d).state.selected && l.push(d.id), d.id
                                };
                            if (t.length && t[0].id !== c && t[0].parent !== c) {
                                for (d = 0, f = t.length; d < f; d++) t[d].children || (t[d].children = []), t[d].state || (t[d].state = {}), g[t[d].id.toString()] = t[d];
                                for (d = 0, f = t.length; d < f; d++) g[t[d].parent.toString()] ? (g[t[d].parent.toString()].children.push(t[d].id.toString()), a.children_d.push(t[d].id.toString())) : void 0 !== j && (j._data.core.last_error = {
                                    error: "parse",
                                    plugin: "core",
                                    id: "core_07",
                                    reason: "Node with invalid parent",
                                    data: JSON.stringify({
                                        id: t[d].id.toString(),
                                        parent: t[d].parent.toString()
                                    })
                                }, j.settings.core.error.call(j, j._data.core.last_error));
                                for (d = 0, f = a.children.length; d < f; d++) o = m(g[a.children[d]], i, a.parents.concat()), s.push(o), g[o].children_d.length && (s = s.concat(g[o].children_d));
                                for (d = 0, f = a.parents.length; d < f; d++) g[a.parents[d]].children_d = g[a.parents[d]].children_d.concat(s);
                                p = {
                                    cnt: u,
                                    mod: g,
                                    sel: n,
                                    par: i,
                                    dpc: s,
                                    add: l
                                }
                            } else {
                                for (d = 0, f = t.length; d < f; d++)(o = v(t[d], i, a.parents.concat())) && (r.push(o), s.push(o), g[o].children_d.length && (s = s.concat(g[o].children_d)));
                                for (a.children = r, a.children_d = s, d = 0, f = a.parents.length; d < f; d++) g[a.parents[d]].children_d = g[a.parents[d]].children_d.concat(s);
                                p = {
                                    cnt: u,
                                    mod: g,
                                    sel: n,
                                    par: i,
                                    dpc: s,
                                    add: l
                                }
                            }
                            if ("undefined" != typeof window && void 0 !== window.document) return p;
                            postMessage(p)
                        },
                        n = function (e, t) {
                            if (null !== this.element) {
                                this._cnt = e.cnt;
                                var i, r = this._model.data;
                                for (i in r) r.hasOwnProperty(i) && r[i].state && r[i].state.loading && e.mod[i] && (e.mod[i].state.loading = !0);
                                if (this._model.data = e.mod, t) {
                                    var s, a = e.add,
                                        n = e.sel,
                                        o = this._data.core.selected.slice();
                                    if (r = this._model.data, n.length !== o.length || S.vakata.array_unique(n.concat(o)).length !== n.length) {
                                        for (i = 0, s = n.length; i < s; i++) - 1 === S.inArray(n[i], a) && -1 === S.inArray(n[i], o) && (r[n[i]].state.selected = !1);
                                        for (i = 0, s = o.length; i < s; i++) - 1 === S.inArray(o[i], n) && (r[o[i]].state.selected = !0)
                                    }
                                }
                                e.add.length && (this._data.core.selected = this._data.core.selected.concat(e.add)), this.trigger("model", {
                                    nodes: e.dpc,
                                    parent: e.par
                                }), e.par !== S.jstree.root ? (this._node_changed(e.par), this.redraw()) : this.redraw(!0), e.add.length && this.trigger("changed", {
                                    action: "model",
                                    selected: this._data.core.selected
                                }), d.call(this, !0)
                            }
                        };
                    if (this.settings.core.worker && window.Blob && window.URL && window.Worker) try {
                        null === this._wrk && (this._wrk = window.URL.createObjectURL(new window.Blob(["self.onmessage = " + a.toString()], {
                            type: "text/javascript"
                        }))), !this._data.core.working || i ? (this._data.core.working = !0, (r = new window.Worker(this._wrk)).onmessage = S.proxy(function (e) {
                            n.call(this, e.data, !0);
                            try {
                                r.terminate(), r = null
                            } catch (e) { }
                            this._data.core.worker_queue.length ? this._append_json_data.apply(this, this._data.core.worker_queue.shift()) : this._data.core.working = !1
                        }, this), s.par ? r.postMessage(s) : this._data.core.worker_queue.length ? this._append_json_data.apply(this, this._data.core.worker_queue.shift()) : this._data.core.working = !1) : this._data.core.worker_queue.push([e, t, d, !0])
                    } catch (e) {
                        n.call(this, a(s), !1), this._data.core.worker_queue.length ? this._append_json_data.apply(this, this._data.core.worker_queue.shift()) : this._data.core.working = !1
                    } else n.call(this, a(s), !1)
                }
            },
            _parse_model_from_html: function (e, t, i) {
                i = i ? [].concat(i) : [], t && i.unshift(t);
                var r, s, a = this._model.data,
                    n = {
                        id: !1,
                        text: !1,
                        icon: !0,
                        parent: t,
                        parents: i,
                        children: [],
                        children_d: [],
                        data: null,
                        state: {},
                        li_attr: {
                            id: !1
                        },
                        a_attr: {
                            href: "#"
                        },
                        original: !1
                    },
                    o, d, c;
                for (o in this._model.default_state) this._model.default_state.hasOwnProperty(o) && (n.state[o] = this._model.default_state[o]);
                if (d = S.vakata.attributes(e, !0), S.each(d, function (e, t) {
                    if (!(t = S.trim(t)).length) return !0;
                    n.li_attr[e] = t, "id" === e && (n.id = t.toString())
                }), (d = e.children("a").first()).length && (d = S.vakata.attributes(d, !0), S.each(d, function (e, t) {
                    (t = S.trim(t)).length && (n.a_attr[e] = t)
                })), (d = e.children("a").first().length ? e.children("a").first().clone() : e.clone()).children("ins, i, ul").remove(), d = d.html(), d = S("<div />").html(d), n.text = this.settings.core.force_text ? d.text() : d.html(), d = e.data(), n.data = d ? S.extend(!0, {}, d) : null, n.state.opened = e.hasClass("jstree-open"), n.state.selected = e.children("a").hasClass("jstree-clicked"), n.state.disabled = e.children("a").hasClass("jstree-disabled"), n.data && n.data.jstree)
                    for (o in n.data.jstree) n.data.jstree.hasOwnProperty(o) && (n.state[o] = n.data.jstree[o]);
                (d = e.children("a").children(".jstree-themeicon")).length && (n.icon = !d.hasClass("jstree-themeicon-hidden") && d.attr("rel")), n.state.icon !== E && (n.icon = n.state.icon), n.icon !== E && null !== n.icon && "" !== n.icon || (n.icon = !0), d = e.children("ul").children("li");
                do {
                    c = "j" + this._id + "_" + ++this._cnt
                } while (a[c]);
                return n.id = n.li_attr.id ? n.li_attr.id.toString() : c, d.length ? (d.each(S.proxy(function (e, t) {
                    r = this._parse_model_from_html(S(t), n.id, i), s = this._model.data[r], n.children.push(r), s.children_d.length && (n.children_d = n.children_d.concat(s.children_d))
                }, this)), n.children_d = n.children_d.concat(n.children)) : e.hasClass("jstree-closed") && (n.state.loaded = !1), n.li_attr.class && (n.li_attr.class = n.li_attr.class.replace("jstree-closed", "").replace("jstree-open", "")), n.a_attr.class && (n.a_attr.class = n.a_attr.class.replace("jstree-clicked", "").replace("jstree-disabled", "")), (a[n.id] = n).state.selected && this._data.core.selected.push(n.id), n.id
            },
            _parse_model_from_flat_json: function (e, t, i) {
                i = i ? i.concat() : [], t && i.unshift(t);
                var r = e.id.toString(),
                    s = this._model.data,
                    a = this._model.default_state,
                    n, o, d, c, l = {
                        id: r,
                        text: e.text || "",
                        icon: e.icon === E || e.icon,
                        parent: t,
                        parents: i,
                        children: e.children || [],
                        children_d: e.children_d || [],
                        data: e.data,
                        state: {},
                        li_attr: {
                            id: !1
                        },
                        a_attr: {
                            href: "#"
                        },
                        original: !1
                    };
                for (n in a) a.hasOwnProperty(n) && (l.state[n] = a[n]);
                if (e && e.data && e.data.jstree && e.data.jstree.icon && (l.icon = e.data.jstree.icon), l.icon !== E && null !== l.icon && "" !== l.icon || (l.icon = !0), e && e.data && (l.data = e.data, e.data.jstree))
                    for (n in e.data.jstree) e.data.jstree.hasOwnProperty(n) && (l.state[n] = e.data.jstree[n]);
                if (e && "object" == typeof e.state)
                    for (n in e.state) e.state.hasOwnProperty(n) && (l.state[n] = e.state[n]);
                if (e && "object" == typeof e.li_attr)
                    for (n in e.li_attr) e.li_attr.hasOwnProperty(n) && (l.li_attr[n] = e.li_attr[n]);
                if (l.li_attr.id || (l.li_attr.id = r), e && "object" == typeof e.a_attr)
                    for (n in e.a_attr) e.a_attr.hasOwnProperty(n) && (l.a_attr[n] = e.a_attr[n]);
                for (e && e.children && !0 === e.children && (l.state.loaded = !1, l.children = [], l.children_d = []), n = 0, o = (s[l.id] = l).children.length; n < o; n++) c = s[d = this._parse_model_from_flat_json(s[l.children[n]], l.id, i)], l.children_d.push(d), c.children_d.length && (l.children_d = l.children_d.concat(c.children_d));
                return delete e.data, delete e.children, s[l.id].original = e, l.state.selected && this._data.core.selected.push(l.id), l.id
            },
            _parse_model_from_json: function (e, t, i) {
                i = i ? i.concat() : [], t && i.unshift(t);
                var r = !1,
                    s, a, n, o, d = this._model.data,
                    c = this._model.default_state,
                    l;
                do {
                    r = "j" + this._id + "_" + ++this._cnt
                } while (d[r]);
                for (s in l = {
                    id: !1,
                    text: "string" == typeof e ? e : "",
                    icon: "object" != typeof e || e.icon === E || e.icon,
                    parent: t,
                    parents: i,
                    children: [],
                    children_d: [],
                    data: null,
                    state: {},
                    li_attr: {
                        id: !1
                    },
                    a_attr: {
                        href: "#"
                    },
                    original: !1
                }, c) c.hasOwnProperty(s) && (l.state[s] = c[s]);
                if (e && e.id && (l.id = e.id.toString()), e && e.text && (l.text = e.text), e && e.data && e.data.jstree && e.data.jstree.icon && (l.icon = e.data.jstree.icon), l.icon !== E && null !== l.icon && "" !== l.icon || (l.icon = !0), e && e.data && (l.data = e.data, e.data.jstree))
                    for (s in e.data.jstree) e.data.jstree.hasOwnProperty(s) && (l.state[s] = e.data.jstree[s]);
                if (e && "object" == typeof e.state)
                    for (s in e.state) e.state.hasOwnProperty(s) && (l.state[s] = e.state[s]);
                if (e && "object" == typeof e.li_attr)
                    for (s in e.li_attr) e.li_attr.hasOwnProperty(s) && (l.li_attr[s] = e.li_attr[s]);
                if (l.li_attr.id && !l.id && (l.id = l.li_attr.id.toString()), l.id || (l.id = r), l.li_attr.id || (l.li_attr.id = l.id), e && "object" == typeof e.a_attr)
                    for (s in e.a_attr) e.a_attr.hasOwnProperty(s) && (l.a_attr[s] = e.a_attr[s]);
                if (e && e.children && e.children.length) {
                    for (s = 0, a = e.children.length; s < a; s++) o = d[n = this._parse_model_from_json(e.children[s], l.id, i)], l.children.push(n), o.children_d.length && (l.children_d = l.children_d.concat(o.children_d));
                    l.children_d = l.children_d.concat(l.children)
                }
                return e && e.children && !0 === e.children && (l.state.loaded = !1, l.children = [], l.children_d = []), delete e.data, delete e.children, l.original = e, (d[l.id] = l).state.selected && this._data.core.selected.push(l.id), l.id
            },
            _redraw: function () {
                var e = this._model.force_full_redraw ? this._model.data[S.jstree.root].children.concat([]) : this._model.changed.concat([]),
                    t = k.createElement("UL"),
                    i, r, s, a = this._data.core.focused;
                for (r = 0, s = e.length; r < s; r++)(i = this.redraw_node(e[r], !0, this._model.force_full_redraw)) && this._model.force_full_redraw && t.appendChild(i);
                this._model.force_full_redraw && (t.className = this.get_container_ul()[0].className, t.setAttribute("role", "group"), this.element.empty().append(t)), null !== a && this.settings.core.restore_focus && ((i = this.get_node(a, !0)) && i.length && i.children(".jstree-anchor")[0] !== k.activeElement ? i.children(".jstree-anchor").focus() : this._data.core.focused = null), this._model.force_full_redraw = !1, this._model.changed = [], this.trigger("redraw", {
                    nodes: e
                })
            },
            redraw: function (e) {
                e && (this._model.force_full_redraw = !0), this._redraw()
            },
            draw_children: function (e) {
                var t = this.get_node(e),
                    i = !1,
                    r = !1,
                    s = !1,
                    a = k;
                if (!t) return !1;
                if (t.id === S.jstree.root) return this.redraw(!0);
                if (!(e = this.get_node(e, !0)) || !e.length) return !1;
                if (e.children(".jstree-children").remove(), e = e[0], t.children.length && t.state.loaded) {
                    for ((s = a.createElement("UL")).setAttribute("role", "group"), s.className = "jstree-children", i = 0, r = t.children.length; i < r; i++) s.appendChild(this.redraw_node(t.children[i], !0, !0));
                    e.appendChild(s)
                }
            },
            redraw_node: function (e, t, i, r) {
                var s = this.get_node(e),
                    a = !1,
                    n = !1,
                    o = !1,
                    d = !1,
                    c = !1,
                    l = !1,
                    h = "",
                    _ = k,
                    u = this._model.data,
                    g = !1,
                    f = !1,
                    p = null,
                    m = 0,
                    v = 0,
                    j = !1,
                    y = !1;
                if (!s) return !1;
                if (s.id === S.jstree.root) return this.redraw(!0);
                if (t = t || 0 === s.children.length, e = k.querySelector ? this.element[0].querySelector("#" + (-1 !== "0123456789".indexOf(s.id[0]) ? "\\3" + s.id[0] + " " + s.id.substr(1).replace(S.jstree.idregex, "\\$&") : s.id.replace(S.jstree.idregex, "\\$&"))) : k.getElementById(s.id)) e = S(e), i || ((a = e.parent().parent()[0]) === this.element[0] && (a = null), n = e.index()), t || !s.children.length || e.children(".jstree-children").length || (t = !0), t || (o = e.children(".jstree-children")[0]), g = e.children(".jstree-anchor")[0] === k.activeElement, e.remove();
                else if (t = !0, !i) {
                    if (!(null === (a = s.parent !== S.jstree.root ? S("#" + s.parent.replace(S.jstree.idregex, "\\$&"), this.element)[0] : null) || a && u[s.parent].state.opened)) return !1;
                    n = S.inArray(s.id, null === a ? u[S.jstree.root].children : u[s.parent].children)
                }
                for (d in e = this._data.core.node.cloneNode(!0), h = "jstree-node ", s.li_attr)
                    if (s.li_attr.hasOwnProperty(d)) {
                        if ("id" === d) continue;
                        "class" !== d ? e.setAttribute(d, s.li_attr[d]) : h += s.li_attr[d]
                    }
                for (s.a_attr.id || (s.a_attr.id = s.id + "_anchor"), e.setAttribute("aria-selected", !!s.state.selected), e.setAttribute("aria-level", s.parents.length), e.setAttribute("aria-labelledby", s.a_attr.id), s.state.disabled && e.setAttribute("aria-disabled", !0), d = 0, c = s.children.length; d < c; d++)
                    if (!u[s.children[d]].state.hidden) {
                        j = !0;
                        break
                    }
                if (null !== s.parent && u[s.parent] && !s.state.hidden && (d = S.inArray(s.id, u[s.parent].children), y = s.id, -1 !== d))
                    for (d++ , c = u[s.parent].children.length; d < c; d++)
                        if (u[u[s.parent].children[d]].state.hidden || (y = u[s.parent].children[d]), y !== s.id) break;
                for (c in s.state.hidden && (h += " jstree-hidden"), s.state.loading && (h += " jstree-loading"), s.state.loaded && !j ? h += " jstree-leaf" : (h += s.state.opened && s.state.loaded ? " jstree-open" : " jstree-closed", e.setAttribute("aria-expanded", s.state.opened && s.state.loaded)), y === s.id && (h += " jstree-last"), e.id = s.id, e.className = h, h = (s.state.selected ? " jstree-clicked" : "") + (s.state.disabled ? " jstree-disabled" : ""), s.a_attr)
                    if (s.a_attr.hasOwnProperty(c)) {
                        if ("href" === c && "#" === s.a_attr[c]) continue;
                        "class" !== c ? e.childNodes[1].setAttribute(c, s.a_attr[c]) : h += " " + s.a_attr[c]
                    }
                if (h.length && (e.childNodes[1].className = "jstree-anchor " + h), (s.icon && !0 !== s.icon || !1 === s.icon) && (!1 === s.icon ? e.childNodes[1].childNodes[0].className += " jstree-themeicon-hidden" : -1 === s.icon.indexOf("/") && -1 === s.icon.indexOf(".") ? e.childNodes[1].childNodes[0].className += " " + s.icon + " jstree-themeicon-custom" : (e.childNodes[1].childNodes[0].style.backgroundImage = 'url("' + s.icon + '")', e.childNodes[1].childNodes[0].style.backgroundPosition = "center center", e.childNodes[1].childNodes[0].style.backgroundSize = "auto", e.childNodes[1].childNodes[0].className += " jstree-themeicon-custom")), this.settings.core.force_text ? e.childNodes[1].appendChild(_.createTextNode(s.text)) : e.childNodes[1].innerHTML += s.text, t && s.children.length && (s.state.opened || r) && s.state.loaded) {
                    for ((l = _.createElement("UL")).setAttribute("role", "group"), l.className = "jstree-children", d = 0, c = s.children.length; d < c; d++) l.appendChild(this.redraw_node(s.children[d], t, !0));
                    e.appendChild(l)
                }
                if (o && e.appendChild(o), !i) {
                    for (a || (a = this.element[0]), d = 0, c = a.childNodes.length; d < c; d++)
                        if (a.childNodes[d] && a.childNodes[d].className && -1 !== a.childNodes[d].className.indexOf("jstree-children")) {
                            p = a.childNodes[d];
                            break
                        }
                    p || ((p = _.createElement("UL")).setAttribute("role", "group"), p.className = "jstree-children", a.appendChild(p)), n < (a = p).childNodes.length ? a.insertBefore(e, a.childNodes[n]) : a.appendChild(e), g && (m = this.element[0].scrollTop, v = this.element[0].scrollLeft, e.childNodes[1].focus(), this.element[0].scrollTop = m, this.element[0].scrollLeft = v)
                }
                return s.state.opened && !s.state.loaded && (s.state.opened = !1, setTimeout(S.proxy(function () {
                    this.open_node(s.id, !1, 0)
                }, this), 0)), e
            },
            open_node: function (e, i, r) {
                var t, s, a, n;
                if (S.isArray(e)) {
                    for (t = 0, s = (e = e.slice()).length; t < s; t++) this.open_node(e[t], i, r);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && (r = r === E ? this.settings.core.animation : r, this.is_closed(e) ? this.is_loaded(e) ? (a = this.get_node(e, !0), n = this, a.length && (r && a.children(".jstree-children").length && a.children(".jstree-children").stop(!0, !0), e.children.length && !this._firstChild(a.children(".jstree-children")[0]) && this.draw_children(e), r ? (this.trigger("before_open", {
                    node: e
                }), a.children(".jstree-children").css("display", "none").end().removeClass("jstree-closed").addClass("jstree-open").attr("aria-expanded", !0).children(".jstree-children").stop(!0, !0).slideDown(r, function () {
                    this.style.display = "", n.element && n.trigger("after_open", {
                        node: e
                    })
                })) : (this.trigger("before_open", {
                    node: e
                }), a[0].className = a[0].className.replace("jstree-closed", "jstree-open"), a[0].setAttribute("aria-expanded", !0))), e.state.opened = !0, i && i.call(this, e, !0), a.length || this.trigger("before_open", {
                    node: e
                }), this.trigger("open_node", {
                    node: e
                }), r && a.length || this.trigger("after_open", {
                    node: e
                }), !0) : this.is_loading(e) ? setTimeout(S.proxy(function () {
                    this.open_node(e, i, r)
                }, this), 500) : void this.load_node(e, function (e, t) {
                    return t ? this.open_node(e, i, r) : !!i && i.call(this, e, !1)
                }) : (i && i.call(this, e, !1), !1))
            },
            _open_to: function (e) {
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                var t, i, r = e.parents;
                for (t = 0, i = r.length; t < i; t += 1) t !== S.jstree.root && this.open_node(r[t], !1, 0);
                return S("#" + e.id.replace(S.jstree.idregex, "\\$&"), this.element)
            },
            close_node: function (e, t) {
                var i, r, s, a;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.close_node(e[i], t);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && (!this.is_closed(e) && (t = t === E ? this.settings.core.animation : t, a = (s = this).get_node(e, !0), e.state.opened = !1, this.trigger("close_node", {
                    node: e
                }), void (a.length ? t ? a.children(".jstree-children").attr("style", "display:block !important").end().removeClass("jstree-open").addClass("jstree-closed").attr("aria-expanded", !1).children(".jstree-children").stop(!0, !0).slideUp(t, function () {
                    this.style.display = "", a.children(".jstree-children").remove(), s.element && s.trigger("after_close", {
                        node: e
                    })
                }) : (a[0].className = a[0].className.replace("jstree-open", "jstree-closed"), a.attr("aria-expanded", !1).children(".jstree-children").remove(), this.trigger("after_close", {
                    node: e
                })) : this.trigger("after_close", {
                    node: e
                }))))
            },
            toggle_node: function (e) {
                var t, i;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.toggle_node(e[t]);
                    return !0
                }
                return this.is_closed(e) ? this.open_node(e) : this.is_open(e) ? this.close_node(e) : void 0
            },
            open_all: function (e, i, r) {
                if (e || (e = S.jstree.root), !(e = this.get_node(e))) return !1;
                var t = e.id === S.jstree.root ? this.get_container_ul() : this.get_node(e, !0),
                    s, a, n;
                if (!t.length) {
                    for (s = 0, a = e.children_d.length; s < a; s++) this.is_closed(this._model.data[e.children_d[s]]) && (this._model.data[e.children_d[s]].state.opened = !0);
                    return this.trigger("open_all", {
                        node: e
                    })
                }
                r = r || t, (t = (n = this).is_closed(e) ? t.find(".jstree-closed").addBack() : t.find(".jstree-closed")).each(function () {
                    n.open_node(this, function (e, t) {
                        t && this.is_parent(e) && this.open_all(e, i, r)
                    }, i || 0)
                }), 0 === r.find(".jstree-closed").length && this.trigger("open_all", {
                    node: this.get_node(r)
                })
            },
            close_all: function (e, t) {
                if (e || (e = S.jstree.root), !(e = this.get_node(e))) return !1;
                var i = e.id === S.jstree.root ? this.get_container_ul() : this.get_node(e, !0),
                    r = this,
                    s, a;
                for (i.length && (i = this.is_open(e) ? i.find(".jstree-open").addBack() : i.find(".jstree-open"), S(i.get().reverse()).each(function () {
                    r.close_node(this, t || 0)
                })), s = 0, a = e.children_d.length; s < a; s++) this._model.data[e.children_d[s]].state.opened = !1;
                this.trigger("close_all", {
                    node: e
                })
            },
            is_disabled: function (e) {
                return (e = this.get_node(e)) && e.state && e.state.disabled
            },
            enable_node: function (e) {
                var t, i;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.enable_node(e[t]);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                e.state.disabled = !1, this.get_node(e, !0).children(".jstree-anchor").removeClass("jstree-disabled").attr("aria-disabled", !1), this.trigger("enable_node", {
                    node: e
                })
            },
            disable_node: function (e) {
                var t, i;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.disable_node(e[t]);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                e.state.disabled = !0, this.get_node(e, !0).children(".jstree-anchor").addClass("jstree-disabled").attr("aria-disabled", !0), this.trigger("disable_node", {
                    node: e
                })
            },
            is_hidden: function (e) {
                return !0 === (e = this.get_node(e)).state.hidden
            },
            hide_node: function (e, t) {
                var i, r;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.hide_node(e[i], !0);
                    return t || this.redraw(), !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                e.state.hidden || (e.state.hidden = !0, this._node_changed(e.parent), t || this.redraw(), this.trigger("hide_node", {
                    node: e
                }))
            },
            show_node: function (e, t) {
                var i, r;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.show_node(e[i], !0);
                    return t || this.redraw(), !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                e.state.hidden && (e.state.hidden = !1, this._node_changed(e.parent), t || this.redraw(), this.trigger("show_node", {
                    node: e
                }))
            },
            hide_all: function (e) {
                var t, i = this._model.data,
                    r = [];
                for (t in i) i.hasOwnProperty(t) && t !== S.jstree.root && !i[t].state.hidden && (i[t].state.hidden = !0, r.push(t));
                return this._model.force_full_redraw = !0, e || this.redraw(), this.trigger("hide_all", {
                    nodes: r
                }), r
            },
            show_all: function (e) {
                var t, i = this._model.data,
                    r = [];
                for (t in i) i.hasOwnProperty(t) && t !== S.jstree.root && i[t].state.hidden && (i[t].state.hidden = !1, r.push(t));
                return this._model.force_full_redraw = !0, e || this.redraw(), this.trigger("show_all", {
                    nodes: r
                }), r
            },
            activate_node: function (e, t) {
                if (this.is_disabled(e)) return !1;
                if (t && "object" == typeof t || (t = {}), this._data.core.last_clicked = this._data.core.last_clicked && this._data.core.last_clicked.id !== E ? this.get_node(this._data.core.last_clicked.id) : null, this._data.core.last_clicked && !this._data.core.last_clicked.state.selected && (this._data.core.last_clicked = null), !this._data.core.last_clicked && this._data.core.selected.length && (this._data.core.last_clicked = this.get_node(this._data.core.selected[this._data.core.selected.length - 1])), this.settings.core.multiple && (t.metaKey || t.ctrlKey || t.shiftKey) && (!t.shiftKey || this._data.core.last_clicked && this.get_parent(e) && this.get_parent(e) === this._data.core.last_clicked.parent))
                    if (t.shiftKey) {
                        var i = this.get_node(e).id,
                            r = this._data.core.last_clicked.id,
                            s = this.get_node(this._data.core.last_clicked.parent).children,
                            a = !1,
                            n, o;
                        for (n = 0, o = s.length; n < o; n += 1) s[n] === i && (a = !a), s[n] === r && (a = !a), this.is_disabled(s[n]) || !a && s[n] !== i && s[n] !== r ? this.deselect_node(s[n], !0, t) : this.is_hidden(s[n]) || this.select_node(s[n], !0, !1, t);
                        this.trigger("changed", {
                            action: "select_node",
                            node: this.get_node(e),
                            selected: this._data.core.selected,
                            event: t
                        })
                    } else this.is_selected(e) ? this.deselect_node(e, !1, t) : this.select_node(e, !1, !1, t);
                else !this.settings.core.multiple && (t.metaKey || t.ctrlKey || t.shiftKey) && this.is_selected(e) ? this.deselect_node(e, !1, t) : (this.deselect_all(!0), this.select_node(e, !1, !1, t), this._data.core.last_clicked = this.get_node(e));
                this.trigger("activate_node", {
                    node: this.get_node(e),
                    event: t
                })
            },
            hover_node: function (e) {
                if (!(e = this.get_node(e, !0)) || !e.length || e.children(".jstree-hovered").length) return !1;
                var t = this.element.find(".jstree-hovered"),
                    i = this.element;
                t && t.length && this.dehover_node(t), e.children(".jstree-anchor").addClass("jstree-hovered"), this.trigger("hover_node", {
                    node: this.get_node(e)
                }), setTimeout(function () {
                    i.attr("aria-activedescendant", e[0].id)
                }, 0)
            },
            dehover_node: function (e) {
                if (!(e = this.get_node(e, !0)) || !e.length || !e.children(".jstree-hovered").length) return !1;
                e.children(".jstree-anchor").removeClass("jstree-hovered"), this.trigger("dehover_node", {
                    node: this.get_node(e)
                })
            },
            select_node: function (e, t, i, r) {
                var s, a, n, o;
                if (S.isArray(e)) {
                    for (a = 0, n = (e = e.slice()).length; a < n; a++) this.select_node(e[a], t, i, r);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                s = this.get_node(e, !0), e.state.selected || (e.state.selected = !0, this._data.core.selected.push(e.id), i || (s = this._open_to(e)), s && s.length && s.attr("aria-selected", !0).children(".jstree-anchor").addClass("jstree-clicked"), this.trigger("select_node", {
                    node: e,
                    selected: this._data.core.selected,
                    event: r
                }), t || this.trigger("changed", {
                    action: "select_node",
                    node: e,
                    selected: this._data.core.selected,
                    event: r
                }))
            },
            deselect_node: function (e, t, i) {
                var r, s, a;
                if (S.isArray(e)) {
                    for (r = 0, s = (e = e.slice()).length; r < s; r++) this.deselect_node(e[r], t, i);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                a = this.get_node(e, !0), e.state.selected && (e.state.selected = !1, this._data.core.selected = S.vakata.array_remove_item(this._data.core.selected, e.id), a.length && a.attr("aria-selected", !1).children(".jstree-anchor").removeClass("jstree-clicked"), this.trigger("deselect_node", {
                    node: e,
                    selected: this._data.core.selected,
                    event: i
                }), t || this.trigger("changed", {
                    action: "deselect_node",
                    node: e,
                    selected: this._data.core.selected,
                    event: i
                }))
            },
            select_all: function (e) {
                var t = this._data.core.selected.concat([]),
                    i, r;
                for (this._data.core.selected = this._model.data[S.jstree.root].children_d.concat(), i = 0, r = this._data.core.selected.length; i < r; i++) this._model.data[this._data.core.selected[i]] && (this._model.data[this._data.core.selected[i]].state.selected = !0);
                this.redraw(!0), this.trigger("select_all", {
                    selected: this._data.core.selected
                }), e || this.trigger("changed", {
                    action: "select_all",
                    selected: this._data.core.selected,
                    old_selection: t
                })
            },
            deselect_all: function (e) {
                var t = this._data.core.selected.concat([]),
                    i, r;
                for (i = 0, r = this._data.core.selected.length; i < r; i++) this._model.data[this._data.core.selected[i]] && (this._model.data[this._data.core.selected[i]].state.selected = !1);
                this._data.core.selected = [], this.element.find(".jstree-clicked").removeClass("jstree-clicked").parent().attr("aria-selected", !1), this.trigger("deselect_all", {
                    selected: this._data.core.selected,
                    node: t
                }), e || this.trigger("changed", {
                    action: "deselect_all",
                    selected: this._data.core.selected,
                    old_selection: t
                })
            },
            is_selected: function (e) {
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && e.state.selected
            },
            get_selected: function (e) {
                return e ? S.map(this._data.core.selected, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : this._data.core.selected.slice()
            },
            get_top_selected: function (e) {
                var t = this.get_selected(!0),
                    i = {},
                    r, s, a, n;
                for (r = 0, s = t.length; r < s; r++) i[t[r].id] = t[r];
                for (r = 0, s = t.length; r < s; r++)
                    for (a = 0, n = t[r].children_d.length; a < n; a++) i[t[r].children_d[a]] && delete i[t[r].children_d[a]];
                for (r in t = [], i) i.hasOwnProperty(r) && t.push(r);
                return e ? S.map(t, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : t
            },
            get_bottom_selected: function (e) {
                var t = this.get_selected(!0),
                    i = [],
                    r, s;
                for (r = 0, s = t.length; r < s; r++) t[r].children.length || i.push(t[r].id);
                return e ? S.map(i, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : i
            },
            get_state: function () {
                var e = {
                    core: {
                        open: [],
                        loaded: [],
                        scroll: {
                            left: this.element.scrollLeft(),
                            top: this.element.scrollTop()
                        },
                        selected: []
                    }
                },
                    t;
                for (t in this._model.data) this._model.data.hasOwnProperty(t) && t !== S.jstree.root && (this._model.data[t].state.loaded && this.settings.core.loaded_state && e.core.loaded.push(t), this._model.data[t].state.opened && e.core.open.push(t), this._model.data[t].state.selected && e.core.selected.push(t));
                return e
            },
            set_state: function (t, i) {
                if (t) {
                    if (t.core && t.core.selected && t.core.initial_selection === E && (t.core.initial_selection = this._data.core.selected.concat([]).sort().join(",")), t.core) {
                        var e, r, s, a, n;
                        if (t.core.loaded) return this.settings.core.loaded_state && S.isArray(t.core.loaded) && t.core.loaded.length ? this._load_nodes(t.core.loaded, function (e) {
                            delete t.core.loaded, this.set_state(t, i)
                        }) : (delete t.core.loaded, this.set_state(t, i)), !1;
                        if (t.core.open) return S.isArray(t.core.open) && t.core.open.length ? this._load_nodes(t.core.open, function (e) {
                            this.open_node(e, !1, 0), delete t.core.open, this.set_state(t, i)
                        }) : (delete t.core.open, this.set_state(t, i)), !1;
                        if (t.core.scroll) return t.core.scroll && t.core.scroll.left !== E && this.element.scrollLeft(t.core.scroll.left), t.core.scroll && t.core.scroll.top !== E && this.element.scrollTop(t.core.scroll.top), delete t.core.scroll, this.set_state(t, i), !1;
                        if (t.core.selected) return a = this, t.core.initial_selection !== E && t.core.initial_selection !== this._data.core.selected.concat([]).sort().join(",") || (this.deselect_all(), S.each(t.core.selected, function (e, t) {
                            a.select_node(t, !1, !0)
                        })), delete t.core.initial_selection, delete t.core.selected, this.set_state(t, i), !1;
                        for (n in t) t.hasOwnProperty(n) && "core" !== n && -1 === S.inArray(n, this.settings.plugins) && delete t[n];
                        if (S.isEmptyObject(t.core)) return delete t.core, this.set_state(t, i), !1
                    }
                    return !S.isEmptyObject(t) || (t = null, i && i.call(this), this.trigger("set_state"), !1)
                }
                return !1
            },
            refresh: function (e, t) {
                this._data.core.state = !0 === t ? {} : this.get_state(), t && S.isFunction(t) && (this._data.core.state = t.call(this, this._data.core.state)), this._cnt = 0, this._model.data = {}, this._model.data[S.jstree.root] = {
                    id: S.jstree.root,
                    parent: null,
                    parents: [],
                    children: [],
                    children_d: [],
                    state: {
                        loaded: !1
                    }
                }, this._data.core.selected = [], this._data.core.last_clicked = null, this._data.core.focused = null;
                var i = this.get_container_ul()[0].className;
                e || (this.element.html("<ul class='" + i + "' role='group'><li class='jstree-initial-node jstree-loading jstree-leaf jstree-last' role='treeitem' id='j" + this._id + "_loading'><i class='jstree-icon jstree-ocl'></i><a class='jstree-anchor' href='#'><i class='jstree-icon jstree-themeicon-hidden'></i>" + this.get_string("Loading ...") + "</a></li></ul>"), this.element.attr("aria-activedescendant", "j" + this._id + "_loading")), this.load_node(S.jstree.root, function (e, t) {
                    t && (this.get_container_ul()[0].className = i, this._firstChild(this.get_container_ul()[0]) && this.element.attr("aria-activedescendant", this._firstChild(this.get_container_ul()[0]).id), this.set_state(S.extend(!0, {}, this._data.core.state), function () {
                        this.trigger("refresh")
                    })), this._data.core.state = null
                })
            },
            refresh_node: function (t) {
                if (!(t = this.get_node(t)) || t.id === S.jstree.root) return !1;
                var i = [],
                    e = [],
                    r = this._data.core.selected.concat([]);
                e.push(t.id), !0 === t.state.opened && i.push(t.id), this.get_node(t, !0).find(".jstree-open").each(function () {
                    e.push(this.id), i.push(this.id)
                }), this._load_nodes(e, S.proxy(function (e) {
                    this.open_node(i, !1, 0), this.select_node(r), this.trigger("refresh_node", {
                        node: t,
                        nodes: e
                    })
                }, this), !1, !0)
            },
            set_id: function (e, t) {
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                var i, r, s = this._model.data,
                    a = e.id;
                for (t = t.toString(), s[e.parent].children[S.inArray(e.id, s[e.parent].children)] = t, i = 0, r = e.parents.length; i < r; i++) s[e.parents[i]].children_d[S.inArray(e.id, s[e.parents[i]].children_d)] = t;
                for (i = 0, r = e.children.length; i < r; i++) s[e.children[i]].parent = t;
                for (i = 0, r = e.children_d.length; i < r; i++) s[e.children_d[i]].parents[S.inArray(e.id, s[e.children_d[i]].parents)] = t;
                return -1 !== (i = S.inArray(e.id, this._data.core.selected)) && (this._data.core.selected[i] = t), (i = this.get_node(e.id, !0)) && (i.attr("id", t), this.element.attr("aria-activedescendant") === e.id && this.element.attr("aria-activedescendant", t)), delete s[e.id], e.id = t, s[e.li_attr.id = t] = e, this.trigger("set_id", {
                    node: e,
                    new: e.id,
                    old: a
                }), !0
            },
            get_text: function (e) {
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && e.text
            },
            set_text: function (e, t) {
                var i, r;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.set_text(e[i], t);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && (e.text = t, this.get_node(e, !0).length && this.redraw_node(e.id), this.trigger("set_text", {
                    obj: e,
                    text: t
                }), !0)
            },
            get_json: function (e, t, i) {
                if (!(e = this.get_node(e || S.jstree.root))) return !1;
                t && t.flat && !i && (i = []);
                var r = {
                    id: e.id,
                    text: e.text,
                    icon: this.get_icon(e),
                    li_attr: S.extend(!0, {}, e.li_attr),
                    a_attr: S.extend(!0, {}, e.a_attr),
                    state: {},
                    data: (!t || !t.no_data) && S.extend(!0, S.isArray(e.data) ? [] : {}, e.data)
                },
                    s, a;
                if (t && t.flat ? r.parent = e.parent : r.children = [], t && t.no_state) delete r.state;
                else
                    for (s in e.state) e.state.hasOwnProperty(s) && (r.state[s] = e.state[s]);
                if (t && t.no_li_attr && delete r.li_attr, t && t.no_a_attr && delete r.a_attr, t && t.no_id && (delete r.id, r.li_attr && r.li_attr.id && delete r.li_attr.id, r.a_attr && r.a_attr.id && delete r.a_attr.id), t && t.flat && e.id !== S.jstree.root && i.push(r), !t || !t.no_children)
                    for (s = 0, a = e.children.length; s < a; s++) t && t.flat ? this.get_json(e.children[s], t, i) : r.children.push(this.get_json(e.children[s], t));
                return t && t.flat ? i : e.id === S.jstree.root ? r.children : r
            },
            create_node: function (e, t, i, r, s) {
                if (null === e && (e = S.jstree.root), !(e = this.get_node(e))) return !1;
                if (!(i = i === E ? "last" : i).toString().match(/^(before|after)$/) && !s && !this.is_loaded(e)) return this.load_node(e, function () {
                    this.create_node(e, t, i, r, !0)
                });
                var a, n, o, d;
                switch (t || (t = {
                    text: this.get_string("New node")
                }), (t = "string" == typeof t ? {
                    text: t
                } : S.extend(!0, {}, t)).text === E && (t.text = this.get_string("New node")), e.id === S.jstree.root && ("before" === i && (i = "first"), "after" === i && (i = "last")), i) {
                    case "before":
                        a = this.get_node(e.parent), i = S.inArray(e.id, a.children), e = a;
                        break;
                    case "after":
                        a = this.get_node(e.parent), i = S.inArray(e.id, a.children) + 1, e = a;
                        break;
                    case "inside":
                    case "first":
                        i = 0;
                        break;
                    case "last":
                        i = e.children.length;
                        break;
                    default:
                        i || (i = 0)
                }
                if (i > e.children.length && (i = e.children.length), t.id || (t.id = !0), !this.check("create_node", t, e, i)) return this.settings.core.error.call(this, this._data.core.last_error), !1;
                if (!0 === t.id && delete t.id, !(t = this._parse_model_from_json(t, e.id, e.parents.concat()))) return !1;
                for (a = this.get_node(t), (n = []).push(t), n = n.concat(a.children_d), this.trigger("model", {
                    nodes: n,
                    parent: e.id
                }), e.children_d = e.children_d.concat(n), o = 0, d = e.parents.length; o < d; o++) this._model.data[e.parents[o]].children_d = this._model.data[e.parents[o]].children_d.concat(n);
                for (t = a, a = [], o = 0, d = e.children.length; o < d; o++) a[i <= o ? o + 1 : o] = e.children[o];
                return a[i] = t.id, e.children = a, this.redraw_node(e, !0), this.trigger("create_node", {
                    node: this.get_node(t),
                    parent: e.id,
                    position: i
                }), r && r.call(this, this.get_node(t)), t.id
            },
            rename_node: function (e, t) {
                var i, r, s;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.rename_node(e[i], t);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && (s = e.text, this.check("rename_node", e, this.get_parent(e), t) ? (this.set_text(e, t), this.trigger("rename_node", {
                    node: e,
                    text: t,
                    old: s
                }), !0) : (this.settings.core.error.call(this, this._data.core.last_error), !1))
            },
            delete_node: function (e) {
                var t, i, r, s, a, n, o, d, c, l, h, _;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.delete_node(e[t]);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                if (r = this.get_node(e.parent), s = S.inArray(e.id, r.children), l = !1, !this.check("delete_node", e, r, s)) return this.settings.core.error.call(this, this._data.core.last_error), !1;
                for (-1 !== s && (r.children = S.vakata.array_remove(r.children, s)), (a = e.children_d.concat([])).push(e.id), n = 0, o = e.parents.length; n < o; n++) this._model.data[e.parents[n]].children_d = S.vakata.array_filter(this._model.data[e.parents[n]].children_d, function (e) {
                    return -1 === S.inArray(e, a)
                });
                for (d = 0, c = a.length; d < c; d++)
                    if (this._model.data[a[d]].state.selected) {
                        l = !0;
                        break
                    }
                for (l && (this._data.core.selected = S.vakata.array_filter(this._data.core.selected, function (e) {
                    return -1 === S.inArray(e, a)
                })), this.trigger("delete_node", {
                    node: e,
                    parent: r.id
                }), l && this.trigger("changed", {
                    action: "delete_node",
                    node: e,
                    selected: this._data.core.selected,
                    parent: r.id
                }), d = 0, c = a.length; d < c; d++) delete this._model.data[a[d]];
                return -1 !== S.inArray(this._data.core.focused, a) && (this._data.core.focused = null, h = this.element[0].scrollTop, _ = this.element[0].scrollLeft, r.id === S.jstree.root ? this._model.data[S.jstree.root].children[0] && this.get_node(this._model.data[S.jstree.root].children[0], !0).children(".jstree-anchor").focus() : this.get_node(r, !0).children(".jstree-anchor").focus(), this.element[0].scrollTop = h, this.element[0].scrollLeft = _), this.redraw_node(r, !0), !0
            },
            check: function (e, t, i, r, s) {
                t = t && t.id ? t : this.get_node(t), i = i && i.id ? i : this.get_node(i);
                var a = e.match(/^move_node|copy_node|create_node$/i) ? i : t,
                    n = this.settings.core.check_callback;
                return "move_node" !== e && "copy_node" !== e || s && s.is_multi || t.id !== i.id && ("move_node" !== e || S.inArray(t.id, i.children) !== r) && -1 === S.inArray(i.id, t.children_d) ? (a && a.data && (a = a.data), a && a.functions && (!1 === a.functions[e] || !0 === a.functions[e]) ? (!1 === a.functions[e] && (this._data.core.last_error = {
                    error: "check",
                    plugin: "core",
                    id: "core_02",
                    reason: "Node data prevents function: " + e,
                    data: JSON.stringify({
                        chk: e,
                        pos: r,
                        obj: !(!t || !t.id) && t.id,
                        par: !(!i || !i.id) && i.id
                    })
                }), a.functions[e]) : !(!1 === n || S.isFunction(n) && !1 === n.call(this, e, t, i, r, s) || n && !1 === n[e]) || !(this._data.core.last_error = {
                    error: "check",
                    plugin: "core",
                    id: "core_03",
                    reason: "User config for core.check_callback prevents function: " + e,
                    data: JSON.stringify({
                        chk: e,
                        pos: r,
                        obj: !(!t || !t.id) && t.id,
                        par: !(!i || !i.id) && i.id
                    })
                })) : !(this._data.core.last_error = {
                    error: "check",
                    plugin: "core",
                    id: "core_01",
                    reason: "Moving parent inside child",
                    data: JSON.stringify({
                        chk: e,
                        pos: r,
                        obj: !(!t || !t.id) && t.id,
                        par: !(!i || !i.id) && i.id
                    })
                })
            },
            last_error: function () {
                return this._data.core.last_error
            },
            move_node: function (e, t, i, r, s, a, n) {
                var o, d, c, l, h, _, u, g, f, p, m, v, j, y;
                if (t = this.get_node(t), i = i === E ? 0 : i, !t) return !1;
                if (!i.toString().match(/^(before|after)$/) && !s && !this.is_loaded(t)) return this.load_node(t, function () {
                    this.move_node(e, t, i, r, !0, !1, n)
                });
                if (S.isArray(e)) {
                    if (1 !== e.length) {
                        for (o = 0, d = e.length; o < d; o++)(f = this.move_node(e[o], t, i, r, s, !1, n)) && (t = f, i = "after");
                        return this.redraw(), !0
                    }
                    e = e[0]
                }
                if (!(e = e && e.id ? e : this.get_node(e)) || e.id === S.jstree.root) return !1;
                if (c = (e.parent || S.jstree.root).toString(), h = i.toString().match(/^(before|after)$/) && t.id !== S.jstree.root ? this.get_node(t.parent) : t, u = !(_ = n || (this._model.data[e.id] ? this : S.jstree.reference(e.id))) || !_._id || this._id !== _._id, l = _ && _._id && c && _._model.data[c] && _._model.data[c].children ? S.inArray(e.id, _._model.data[c].children) : -1, _ && _._id && (e = _._model.data[e.id]), u) return !!(f = this.copy_node(e, t, i, r, s, !1, n)) && (_ && _.delete_node(e), f);
                switch (t.id === S.jstree.root && ("before" === i && (i = "first"), "after" === i && (i = "last")), i) {
                    case "before":
                        i = S.inArray(t.id, h.children);
                        break;
                    case "after":
                        i = S.inArray(t.id, h.children) + 1;
                        break;
                    case "inside":
                    case "first":
                        i = 0;
                        break;
                    case "last":
                        i = h.children.length;
                        break;
                    default:
                        i || (i = 0)
                }
                if (i > h.children.length && (i = h.children.length), !this.check("move_node", e, h, i, {
                    core: !0,
                    origin: n,
                    is_multi: _ && _._id && _._id !== this._id,
                    is_foreign: !_ || !_._id
                })) return this.settings.core.error.call(this, this._data.core.last_error), !1;
                if (e.parent === h.id) {
                    for (g = h.children.concat(), -1 !== (f = S.inArray(e.id, g)) && (g = S.vakata.array_remove(g, f), f < i && i--), f = [], p = 0, m = g.length; p < m; p++) f[i <= p ? p + 1 : p] = g[p];
                    f[i] = e.id, h.children = f, this._node_changed(h.id), this.redraw(h.id === S.jstree.root)
                } else {
                    for ((f = e.children_d.concat()).push(e.id), p = 0, m = e.parents.length; p < m; p++) {
                        for (g = [], v = 0, j = (y = _._model.data[e.parents[p]].children_d).length; v < j; v++) - 1 === S.inArray(y[v], f) && g.push(y[v]);
                        _._model.data[e.parents[p]].children_d = g
                    }
                    for (_._model.data[c].children = S.vakata.array_remove_item(_._model.data[c].children, e.id), p = 0, m = h.parents.length; p < m; p++) this._model.data[h.parents[p]].children_d = this._model.data[h.parents[p]].children_d.concat(f);
                    for (g = [], p = 0, m = h.children.length; p < m; p++) g[i <= p ? p + 1 : p] = h.children[p];
                    for (g[i] = e.id, h.children = g, h.children_d.push(e.id), h.children_d = h.children_d.concat(e.children_d), e.parent = h.id, (f = h.parents.concat()).unshift(h.id), y = e.parents.length, f = (e.parents = f).concat(), p = 0, m = e.children_d.length; p < m; p++) this._model.data[e.children_d[p]].parents = this._model.data[e.children_d[p]].parents.slice(0, -1 * y), Array.prototype.push.apply(this._model.data[e.children_d[p]].parents, f);
                    c !== S.jstree.root && h.id !== S.jstree.root || (this._model.force_full_redraw = !0), this._model.force_full_redraw || (this._node_changed(c), this._node_changed(h.id)), a || this.redraw()
                }
                return r && r.call(this, e, h, i), this.trigger("move_node", {
                    node: e,
                    parent: h.id,
                    position: i,
                    old_parent: c,
                    old_position: l,
                    is_multi: _ && _._id && _._id !== this._id,
                    is_foreign: !_ || !_._id,
                    old_instance: _,
                    new_instance: this
                }), e.id
            },
            copy_node: function (e, t, i, r, s, a, n) {
                var o, d, c, l, h, _, u, g, f, p, m;
                if (t = this.get_node(t), i = i === E ? 0 : i, !t) return !1;
                if (!i.toString().match(/^(before|after)$/) && !s && !this.is_loaded(t)) return this.load_node(t, function () {
                    this.copy_node(e, t, i, r, !0, !1, n)
                });
                if (S.isArray(e)) {
                    if (1 !== e.length) {
                        for (o = 0, d = e.length; o < d; o++)(l = this.copy_node(e[o], t, i, r, s, !0, n)) && (t = l, i = "after");
                        return this.redraw(), !0
                    }
                    e = e[0]
                }
                if (!(e = e && e.id ? e : this.get_node(e)) || e.id === S.jstree.root) return !1;
                switch (g = (e.parent || S.jstree.root).toString(), f = i.toString().match(/^(before|after)$/) && t.id !== S.jstree.root ? this.get_node(t.parent) : t, m = !(p = n || (this._model.data[e.id] ? this : S.jstree.reference(e.id))) || !p._id || this._id !== p._id, p && p._id && (e = p._model.data[e.id]), t.id === S.jstree.root && ("before" === i && (i = "first"), "after" === i && (i = "last")), i) {
                    case "before":
                        i = S.inArray(t.id, f.children);
                        break;
                    case "after":
                        i = S.inArray(t.id, f.children) + 1;
                        break;
                    case "inside":
                    case "first":
                        i = 0;
                        break;
                    case "last":
                        i = f.children.length;
                        break;
                    default:
                        i || (i = 0)
                }
                if (i > f.children.length && (i = f.children.length), !this.check("copy_node", e, f, i, {
                    core: !0,
                    origin: n,
                    is_multi: p && p._id && p._id !== this._id,
                    is_foreign: !p || !p._id
                })) return this.settings.core.error.call(this, this._data.core.last_error), !1;
                if (!(u = p ? p.get_json(e, {
                    no_id: !0,
                    no_data: !0,
                    no_state: !0
                }) : e)) return !1;
                if (!0 === u.id && delete u.id, !(u = this._parse_model_from_json(u, f.id, f.parents.concat()))) return !1;
                for (l = this.get_node(u), e && e.state && !1 === e.state.loaded && (l.state.loaded = !1), (c = []).push(u), c = c.concat(l.children_d), this.trigger("model", {
                    nodes: c,
                    parent: f.id
                }), h = 0, _ = f.parents.length; h < _; h++) this._model.data[f.parents[h]].children_d = this._model.data[f.parents[h]].children_d.concat(c);
                for (c = [], h = 0, _ = f.children.length; h < _; h++) c[i <= h ? h + 1 : h] = f.children[h];
                return c[i] = l.id, f.children = c, f.children_d.push(l.id), f.children_d = f.children_d.concat(l.children_d), f.id === S.jstree.root && (this._model.force_full_redraw = !0), this._model.force_full_redraw || this._node_changed(f.id), a || this.redraw(f.id === S.jstree.root), r && r.call(this, l, f, i), this.trigger("copy_node", {
                    node: l,
                    original: e,
                    parent: f.id,
                    position: i,
                    old_parent: g,
                    old_position: p && p._id && g && p._model.data[g] && p._model.data[g].children ? S.inArray(e.id, p._model.data[g].children) : -1,
                    is_multi: p && p._id && p._id !== this._id,
                    is_foreign: !p || !p._id,
                    old_instance: p,
                    new_instance: this
                }), l.id
            },
            cut: function (e) {
                if (e || (e = this._data.core.selected.concat()), S.isArray(e) || (e = [e]), !e.length) return !1;
                var t = [],
                    i, r, s;
                for (r = 0, s = e.length; r < s; r++)(i = this.get_node(e[r])) && i.id && i.id !== S.jstree.root && t.push(i);
                if (!t.length) return !1;
                a = t, n = "move_node", (o = this).trigger("cut", {
                    node: e
                })
            },
            copy: function (e) {
                if (e || (e = this._data.core.selected.concat()), S.isArray(e) || (e = [e]), !e.length) return !1;
                var t = [],
                    i, r, s;
                for (r = 0, s = e.length; r < s; r++)(i = this.get_node(e[r])) && i.id && i.id !== S.jstree.root && t.push(i);
                if (!t.length) return !1;
                a = t, n = "copy_node", (o = this).trigger("copy", {
                    node: e
                })
            },
            get_buffer: function () {
                return {
                    mode: n,
                    node: a,
                    inst: o
                }
            },
            can_paste: function () {
                return !1 !== n && !1 !== a
            },
            paste: function (e, t) {
                if (!((e = this.get_node(e)) && n && n.match(/^(copy_node|move_node)$/) && a)) return !1;
                this[n](a, e, t, !1, !1, !1, o) && this.trigger("paste", {
                    parent: e.id,
                    node: a,
                    mode: n
                }), o = n = a = !1
            },
            clear_buffer: function () {
                o = n = a = !1, this.trigger("clear_buffer")
            },
            edit: function (a, e, n) {
                var t, i, o, d, c, l, h, r, _, u = !1;
                return !!(a = this.get_node(a)) && (this.check("edit", a, this.get_parent(a)) ? (_ = a, e = "string" == typeof e ? e : a.text, this.set_text(a, ""), a = this._open_to(a), _.text = e, t = this._data.core.rtl, i = this.element.width(), this._data.core.focused = _.id, o = a.children(".jstree-anchor").focus(), d = S("<span>"), c = e, l = S("<div />", {
                    css: {
                        position: "absolute",
                        top: "-200px",
                        left: t ? "0px" : "-1000px",
                        visibility: "hidden"
                    }
                }).appendTo(k.body), h = S("<input />", {
                    value: c,
                    class: "jstree-rename-input",
                    css: {
                        padding: "0",
                        border: "1px solid silver",
                        "box-sizing": "border-box",
                        display: "inline-block",
                        height: this._data.core.li_height + "px",
                        lineHeight: this._data.core.li_height + "px",
                        width: "150px"
                    },
                    blur: S.proxy(function (e) {
                        e.stopImmediatePropagation(), e.preventDefault();
                        var t, i = d.children(".jstree-rename-input").val(),
                            r = this.settings.core.force_text,
                            s;
                        "" === i && (i = c), l.remove(), d.replaceWith(o), d.remove(), c = r ? c : S("<div></div>").append(S.parseHTML(c)).html(), a = this.get_node(a), this.set_text(a, c), (s = !!this.rename_node(a, r ? S("<div></div>").text(i).text() : S("<div></div>").append(S.parseHTML(i)).html())) || this.set_text(a, c), this._data.core.focused = _.id, setTimeout(S.proxy(function () {
                            var e = this.get_node(_.id, !0);
                            e.length && (this._data.core.focused = _.id, e.children(".jstree-anchor").focus())
                        }, this), 0), n && n.call(this, _, s, u), h = null
                    }, this),
                    keydown: function (e) {
                        var t = e.which;
                        27 === t && (u = !0, this.value = c), 27 !== t && 13 !== t && 37 !== t && 38 !== t && 39 !== t && 40 !== t && 32 !== t || e.stopImmediatePropagation(), 27 !== t && 13 !== t || (e.preventDefault(), this.blur())
                    },
                    click: function (e) {
                        e.stopImmediatePropagation()
                    },
                    mousedown: function (e) {
                        e.stopImmediatePropagation()
                    },
                    keyup: function (e) {
                        h.width(Math.min(l.text("pW" + this.value).width(), i))
                    },
                    keypress: function (e) {
                        if (13 === e.which) return !1
                    }
                }), r = {
                    fontFamily: o.css("fontFamily") || "",
                    fontSize: o.css("fontSize") || "",
                    fontWeight: o.css("fontWeight") || "",
                    fontStyle: o.css("fontStyle") || "",
                    fontStretch: o.css("fontStretch") || "",
                    fontVariant: o.css("fontVariant") || "",
                    letterSpacing: o.css("letterSpacing") || "",
                    wordSpacing: o.css("wordSpacing") || ""
                }, d.attr("class", o.attr("class")).append(o.contents().clone()).append(h), o.replaceWith(d), l.css(r), h.css(r).width(Math.min(l.text("pW" + h[0].value).width(), i))[0].select(), void S(k).one("mousedown.jstree touchstart.jstree dnd_start.vakata", function (e) {
                    h && e.target !== h && S(h).blur()
                })) : (this.settings.core.error.call(this, this._data.core.last_error), !1))
            },
            set_theme: function (e, t) {
                if (!e) return !1;
                if (!0 === t) {
                    var i = this.settings.core.themes.dir;
                    i || (i = S.jstree.path + "/themes"), t = i + "/" + e + "/style.css"
                }
                t && -1 === S.inArray(t, r) && (S("head").append('<link rel="stylesheet" href="' + t + '" type="text/css" />'), r.push(t)), this._data.core.themes.name && this.element.removeClass("jstree-" + this._data.core.themes.name), this._data.core.themes.name = e, this.element.addClass("jstree-" + e), this.element[this.settings.core.themes.responsive ? "addClass" : "removeClass"]("jstree-" + e + "-responsive"), this.trigger("set_theme", {
                    theme: e
                })
            },
            get_theme: function () {
                return this._data.core.themes.name
            },
            set_theme_variant: function (e) {
                this._data.core.themes.variant && this.element.removeClass("jstree-" + this._data.core.themes.name + "-" + this._data.core.themes.variant), (this._data.core.themes.variant = e) && this.element.addClass("jstree-" + this._data.core.themes.name + "-" + this._data.core.themes.variant)
            },
            get_theme_variant: function () {
                return this._data.core.themes.variant
            },
            show_stripes: function () {
                this._data.core.themes.stripes = !0, this.get_container_ul().addClass("jstree-striped"), this.trigger("show_stripes")
            },
            hide_stripes: function () {
                this._data.core.themes.stripes = !1, this.get_container_ul().removeClass("jstree-striped"), this.trigger("hide_stripes")
            },
            toggle_stripes: function () {
                this._data.core.themes.stripes ? this.hide_stripes() : this.show_stripes()
            },
            show_dots: function () {
                this._data.core.themes.dots = !0, this.get_container_ul().removeClass("jstree-no-dots"), this.trigger("show_dots")
            },
            hide_dots: function () {
                this._data.core.themes.dots = !1, this.get_container_ul().addClass("jstree-no-dots"), this.trigger("hide_dots")
            },
            toggle_dots: function () {
                this._data.core.themes.dots ? this.hide_dots() : this.show_dots()
            },
            show_icons: function () {
                this._data.core.themes.icons = !0, this.get_container_ul().removeClass("jstree-no-icons"), this.trigger("show_icons")
            },
            hide_icons: function () {
                this._data.core.themes.icons = !1, this.get_container_ul().addClass("jstree-no-icons"), this.trigger("hide_icons")
            },
            toggle_icons: function () {
                this._data.core.themes.icons ? this.hide_icons() : this.show_icons()
            },
            show_ellipsis: function () {
                this._data.core.themes.ellipsis = !0, this.get_container_ul().addClass("jstree-ellipsis"), this.trigger("show_ellipsis")
            },
            hide_ellipsis: function () {
                this._data.core.themes.ellipsis = !1, this.get_container_ul().removeClass("jstree-ellipsis"), this.trigger("hide_ellipsis")
            },
            toggle_ellipsis: function () {
                this._data.core.themes.ellipsis ? this.hide_ellipsis() : this.show_ellipsis()
            },
            set_icon: function (e, t) {
                var i, r, s, a;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.set_icon(e[i], t);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && (a = e.icon, e.icon = !0 === t || null === t || t === E || "" === t || t, s = this.get_node(e, !0).children(".jstree-anchor").children(".jstree-themeicon"), !1 === t ? (s.removeClass("jstree-themeicon-custom " + a).css("background", "").removeAttr("rel"), this.hide_icon(e)) : (!0 === t || null === t || t === E || "" === t ? s.removeClass("jstree-themeicon-custom " + a).css("background", "").removeAttr("rel") : -1 === t.indexOf("/") && -1 === t.indexOf(".") ? (s.removeClass(a).css("background", ""), s.addClass(t + " jstree-themeicon-custom").attr("rel", t)) : (s.removeClass(a).css("background", ""), s.addClass("jstree-themeicon-custom").css("background", "url('" + t + "') center center no-repeat").attr("rel", t)), !1 === a && this.show_icon(e)), !0)
            },
            get_icon: function (e) {
                return !(!(e = this.get_node(e)) || e.id === S.jstree.root) && e.icon
            },
            hide_icon: function (e) {
                var t, i;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.hide_icon(e[t]);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e === S.jstree.root) && (e.icon = !1, this.get_node(e, !0).children(".jstree-anchor").children(".jstree-themeicon").addClass("jstree-themeicon-hidden"), !0)
            },
            show_icon: function (e) {
                var t, i, r;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.show_icon(e[t]);
                    return !0
                }
                return !(!(e = this.get_node(e)) || e === S.jstree.root) && (r = this.get_node(e, !0), e.icon = !r.length || r.children(".jstree-anchor").children(".jstree-themeicon").attr("rel"), e.icon || (e.icon = !0), r.children(".jstree-anchor").children(".jstree-themeicon").removeClass("jstree-themeicon-hidden"), !0)
            }
        }, S.vakata = {}, S.vakata.attributes = function (e, i) {
            e = S(e)[0];
            var r = i ? {} : [];
            return e && e.attributes && S.each(e.attributes, function (e, t) {
                -1 === S.inArray(t.name.toLowerCase(), ["style", "contenteditable", "hasfocus", "tabindex"]) && null !== t.value && "" !== S.trim(t.value) && (i ? r[t.name] = t.value : r.push(t.name))
            }), r
        }, S.vakata.array_unique = function (e) {
            var t = [],
                i, r, s, a = {};
            for (i = 0, s = e.length; i < s; i++) a[e[i]] === E && (t.push(e[i]), a[e[i]] = !0);
            return t
        }, S.vakata.array_remove = function (e, t) {
            return e.splice(t, 1), e
        }, S.vakata.array_remove_item = function (e, t) {
            var i = S.inArray(t, e);
            return -1 !== i ? S.vakata.array_remove(e, i) : e
        }, S.vakata.array_filter = function (e, t, i, r, s) {
            if (e.filter) return e.filter(t, i);
            for (s in r = [], e) ~~s + "" == s + "" && 0 <= s && t.call(i, e[s], +s, e) && r.push(e[s]);
            return r
        }, S.jstree.plugins.changed = function (e, a) {
            var n = [];
            this.trigger = function (e, t) {
                var i, r;
                if (t || (t = {}), "changed" === e.replace(".jstree", "")) {
                    t.changed = {
                        selected: [],
                        deselected: []
                    };
                    var s = {};
                    for (i = 0, r = n.length; i < r; i++) s[n[i]] = 1;
                    for (i = 0, r = t.selected.length; i < r; i++) s[t.selected[i]] ? s[t.selected[i]] = 2 : t.changed.selected.push(t.selected[i]);
                    for (i = 0, r = n.length; i < r; i++) 1 === s[n[i]] && t.changed.deselected.push(n[i]);
                    n = t.selected.slice()
                }
                a.trigger.call(this, e, t)
            }, this.refresh = function (e, t) {
                return n = [], a.refresh.apply(this, arguments)
            }
        };
        var c = k.createElement("I"),
            _, u, g, d, l, h, f, i;
        c.className = "jstree-icon jstree-checkbox", c.setAttribute("role", "presentation"), S.jstree.defaults.checkbox = {
            visible: !0,
            three_state: !0,
            whole_node: !0,
            keep_selected_style: !0,
            cascade: "",
            tie_selection: !0,
            cascade_to_disabled: !0,
            cascade_to_hidden: !0
        }, S.jstree.plugins.checkbox = function (e, d) {
            this.bind = function () {
                d.bind.call(this), this._data.checkbox.uto = !1, this._data.checkbox.selected = [], this.settings.checkbox.three_state && (this.settings.checkbox.cascade = "up+down+undetermined"), this.element.on("init.jstree", S.proxy(function () {
                    this._data.checkbox.visible = this.settings.checkbox.visible, this.settings.checkbox.keep_selected_style || this.element.addClass("jstree-checkbox-no-clicked"), this.settings.checkbox.tie_selection && this.element.addClass("jstree-checkbox-selection")
                }, this)).on("loading.jstree", S.proxy(function () {
                    this[this._data.checkbox.visible ? "show_checkboxes" : "hide_checkboxes"]()
                }, this)), -1 !== this.settings.checkbox.cascade.indexOf("undetermined") && this.element.on("changed.jstree uncheck_node.jstree check_node.jstree uncheck_all.jstree check_all.jstree move_node.jstree copy_node.jstree redraw.jstree open_node.jstree", S.proxy(function () {
                    this._data.checkbox.uto && clearTimeout(this._data.checkbox.uto), this._data.checkbox.uto = setTimeout(S.proxy(this._undetermined, this), 50)
                }, this)), this.settings.checkbox.tie_selection || this.element.on("model.jstree", S.proxy(function (e, t) {
                    var i = this._model.data,
                        r = i[t.parent],
                        s = t.nodes,
                        a, n;
                    for (a = 0, n = s.length; a < n; a++) i[s[a]].state.checked = i[s[a]].state.checked || i[s[a]].original && i[s[a]].original.state && i[s[a]].original.state.checked, i[s[a]].state.checked && this._data.checkbox.selected.push(s[a])
                }, this)), -1 === this.settings.checkbox.cascade.indexOf("up") && -1 === this.settings.checkbox.cascade.indexOf("down") || this.element.on("model.jstree", S.proxy(function (e, t) {
                    var i = this._model.data,
                        r = i[t.parent],
                        s = t.nodes,
                        a = [],
                        n, o, d, c, l, h, _ = this.settings.checkbox.cascade,
                        u = this.settings.checkbox.tie_selection;
                    if (-1 !== _.indexOf("down"))
                        if (r.state[u ? "selected" : "checked"]) {
                            for (o = 0, d = s.length; o < d; o++) i[s[o]].state[u ? "selected" : "checked"] = !0;
                            this._data[u ? "core" : "checkbox"].selected = this._data[u ? "core" : "checkbox"].selected.concat(s)
                        } else
                            for (o = 0, d = s.length; o < d; o++)
                                if (i[s[o]].state[u ? "selected" : "checked"]) {
                                    for (c = 0, l = i[s[o]].children_d.length; c < l; c++) i[i[s[o]].children_d[c]].state[u ? "selected" : "checked"] = !0;
                                    this._data[u ? "core" : "checkbox"].selected = this._data[u ? "core" : "checkbox"].selected.concat(i[s[o]].children_d)
                                }
                    if (-1 !== _.indexOf("up")) {
                        for (o = 0, d = r.children_d.length; o < d; o++) i[r.children_d[o]].children.length || a.push(i[r.children_d[o]].parent);
                        for (c = 0, l = (a = S.vakata.array_unique(a)).length; c < l; c++) {
                            r = i[a[c]];
                            while (r && r.id !== S.jstree.root) {
                                for (o = n = 0, d = r.children.length; o < d; o++) n += i[r.children[o]].state[u ? "selected" : "checked"];
                                if (n !== d) break;
                                r.state[u ? "selected" : "checked"] = !0, this._data[u ? "core" : "checkbox"].selected.push(r.id), (h = this.get_node(r, !0)) && h.length && h.attr("aria-selected", !0).children(".jstree-anchor").addClass(u ? "jstree-clicked" : "jstree-checked"), r = this.get_node(r.parent)
                            }
                        }
                    }
                    this._data[u ? "core" : "checkbox"].selected = S.vakata.array_unique(this._data[u ? "core" : "checkbox"].selected)
                }, this)).on(this.settings.checkbox.tie_selection ? "select_node.jstree" : "check_node.jstree", S.proxy(function (e, t) {
                    var i = this,
                        r = t.node,
                        s = this._model.data,
                        a = this.get_node(r.parent),
                        n, o, d, c, l = this.settings.checkbox.cascade,
                        h = this.settings.checkbox.tie_selection,
                        _ = {},
                        u = this._data[h ? "core" : "checkbox"].selected;
                    for (n = 0, o = u.length; n < o; n++) _[u[n]] = !0;
                    if (-1 !== l.indexOf("down")) {
                        var g = this._cascade_new_checked_state(r.id, !0),
                            f = r.children_d.concat(r.id);
                        for (n = 0, o = f.length; n < o; n++) - 1 < g.indexOf(f[n]) ? _[f[n]] = !0 : delete _[f[n]]
                    }
                    if (-1 !== l.indexOf("up"))
                        while (a && a.id !== S.jstree.root) {
                            for (n = d = 0, o = a.children.length; n < o; n++) d += s[a.children[n]].state[h ? "selected" : "checked"];
                            if (d !== o) break;
                            a.state[h ? "selected" : "checked"] = !0, _[a.id] = !0, (c = this.get_node(a, !0)) && c.length && c.attr("aria-selected", !0).children(".jstree-anchor").addClass(h ? "jstree-clicked" : "jstree-checked"), a = this.get_node(a.parent)
                        }
                    for (n in u = [], _) _.hasOwnProperty(n) && u.push(n);
                    this._data[h ? "core" : "checkbox"].selected = u
                }, this)).on(this.settings.checkbox.tie_selection ? "deselect_all.jstree" : "uncheck_all.jstree", S.proxy(function (e, t) {
                    var i = this.get_node(S.jstree.root),
                        r = this._model.data,
                        s, a, n;
                    for (s = 0, a = i.children_d.length; s < a; s++)(n = r[i.children_d[s]]) && n.original && n.original.state && n.original.state.undetermined && (n.original.state.undetermined = !1)
                }, this)).on(this.settings.checkbox.tie_selection ? "deselect_node.jstree" : "uncheck_node.jstree", S.proxy(function (e, t) {
                    var i = this,
                        r = t.node,
                        s = this.get_node(r, !0),
                        a, n, o, d = this.settings.checkbox.cascade,
                        c = this.settings.checkbox.tie_selection,
                        l = this._data[c ? "core" : "checkbox"].selected,
                        h = {},
                        _ = [],
                        u = r.children_d.concat(r.id);
                    if (-1 !== d.indexOf("down")) {
                        var g = this._cascade_new_checked_state(r.id, !1);
                        l = l.filter(function (e) {
                            return -1 === u.indexOf(e) || -1 < g.indexOf(e)
                        })
                    }
                    if (-1 !== d.indexOf("up") && -1 === l.indexOf(r.id)) {
                        for (a = 0, n = r.parents.length; a < n; a++)(o = this._model.data[r.parents[a]]).state[c ? "selected" : "checked"] = !1, o && o.original && o.original.state && o.original.state.undetermined && (o.original.state.undetermined = !1), (o = this.get_node(r.parents[a], !0)) && o.length && o.attr("aria-selected", !1).children(".jstree-anchor").removeClass(c ? "jstree-clicked" : "jstree-checked");
                        l = l.filter(function (e) {
                            return -1 === r.parents.indexOf(e)
                        })
                    }
                    this._data[c ? "core" : "checkbox"].selected = l
                }, this)), -1 !== this.settings.checkbox.cascade.indexOf("up") && this.element.on("delete_node.jstree", S.proxy(function (e, t) {
                    var i = this.get_node(t.parent),
                        r = this._model.data,
                        s, a, n, o, d = this.settings.checkbox.tie_selection;
                    while (i && i.id !== S.jstree.root && !i.state[d ? "selected" : "checked"]) {
                        for (s = n = 0, a = i.children.length; s < a; s++) n += r[i.children[s]].state[d ? "selected" : "checked"];
                        if (!(0 < a && n === a)) break;
                        i.state[d ? "selected" : "checked"] = !0, this._data[d ? "core" : "checkbox"].selected.push(i.id), (o = this.get_node(i, !0)) && o.length && o.attr("aria-selected", !0).children(".jstree-anchor").addClass(d ? "jstree-clicked" : "jstree-checked"), i = this.get_node(i.parent)
                    }
                }, this)).on("move_node.jstree", S.proxy(function (e, t) {
                    var i = t.is_multi,
                        r = t.old_parent,
                        s = this.get_node(t.parent),
                        a = this._model.data,
                        n, o, d, c, l, h = this.settings.checkbox.tie_selection;
                    if (!i) {
                        n = this.get_node(r);
                        while (n && n.id !== S.jstree.root && !n.state[h ? "selected" : "checked"]) {
                            for (d = o = 0, c = n.children.length; d < c; d++) o += a[n.children[d]].state[h ? "selected" : "checked"];
                            if (!(0 < c && o === c)) break;
                            n.state[h ? "selected" : "checked"] = !0, this._data[h ? "core" : "checkbox"].selected.push(n.id), (l = this.get_node(n, !0)) && l.length && l.attr("aria-selected", !0).children(".jstree-anchor").addClass(h ? "jstree-clicked" : "jstree-checked"), n = this.get_node(n.parent)
                        }
                    }
                    n = s;
                    while (n && n.id !== S.jstree.root) {
                        for (d = o = 0, c = n.children.length; d < c; d++) o += a[n.children[d]].state[h ? "selected" : "checked"];
                        if (o === c) n.state[h ? "selected" : "checked"] || (n.state[h ? "selected" : "checked"] = !0, this._data[h ? "core" : "checkbox"].selected.push(n.id), (l = this.get_node(n, !0)) && l.length && l.attr("aria-selected", !0).children(".jstree-anchor").addClass(h ? "jstree-clicked" : "jstree-checked"));
                        else {
                            if (!n.state[h ? "selected" : "checked"]) break;
                            n.state[h ? "selected" : "checked"] = !1, this._data[h ? "core" : "checkbox"].selected = S.vakata.array_remove_item(this._data[h ? "core" : "checkbox"].selected, n.id), (l = this.get_node(n, !0)) && l.length && l.attr("aria-selected", !1).children(".jstree-anchor").removeClass(h ? "jstree-clicked" : "jstree-checked")
                        }
                        n = this.get_node(n.parent)
                    }
                }, this))
            }, this.get_undetermined = function (e) {
                if (-1 === this.settings.checkbox.cascade.indexOf("undetermined")) return [];
                var i, r, s, a, n = {},
                    o = this._model.data,
                    t = this.settings.checkbox.tie_selection,
                    d = this._data[t ? "core" : "checkbox"].selected,
                    c = [],
                    l = this,
                    h = [];
                for (i = 0, r = d.length; i < r; i++)
                    if (o[d[i]] && o[d[i]].parents)
                        for (s = 0, a = o[d[i]].parents.length; s < a; s++) {
                            if (n[o[d[i]].parents[s]] !== E) break;
                            o[d[i]].parents[s] !== S.jstree.root && (n[o[d[i]].parents[s]] = !0, c.push(o[d[i]].parents[s]))
                        }
                for (this.element.find(".jstree-closed").not(":has(.jstree-children)").each(function () {
                    var e = l.get_node(this),
                        t;
                    if (e)
                        if (e.state.loaded) {
                            for (i = 0, r = e.children_d.length; i < r; i++)
                                if (!(t = o[e.children_d[i]]).state.loaded && t.original && t.original.state && t.original.state.undetermined && !0 === t.original.state.undetermined)
                                    for (n[t.id] === E && t.id !== S.jstree.root && (n[t.id] = !0, c.push(t.id)), s = 0, a = t.parents.length; s < a; s++) n[t.parents[s]] === E && t.parents[s] !== S.jstree.root && (n[t.parents[s]] = !0, c.push(t.parents[s]))
                        } else if (e.original && e.original.state && e.original.state.undetermined && !0 === e.original.state.undetermined)
                            for (n[e.id] === E && e.id !== S.jstree.root && (n[e.id] = !0, c.push(e.id)), s = 0, a = e.parents.length; s < a; s++) n[e.parents[s]] === E && e.parents[s] !== S.jstree.root && (n[e.parents[s]] = !0, c.push(e.parents[s]))
                }), i = 0, r = c.length; i < r; i++) o[c[i]].state[t ? "selected" : "checked"] || h.push(e ? o[c[i]] : c[i]);
                return h
            }, this._undetermined = function () {
                if (null !== this.element) {
                    var e = this.get_undetermined(!1),
                        t, i, r;
                    for (this.element.find(".jstree-undetermined").removeClass("jstree-undetermined"), t = 0, i = e.length; t < i; t++)(r = this.get_node(e[t], !0)) && r.length && r.children(".jstree-anchor").children(".jstree-checkbox").addClass("jstree-undetermined")
                }
            }, this.redraw_node = function (e, t, i, r) {
                if (e = d.redraw_node.apply(this, arguments)) {
                    var s, a, n = null,
                        o = null;
                    for (s = 0, a = e.childNodes.length; s < a; s++)
                        if (e.childNodes[s] && e.childNodes[s].className && -1 !== e.childNodes[s].className.indexOf("jstree-anchor")) {
                            n = e.childNodes[s];
                            break
                        }
                    n && (!this.settings.checkbox.tie_selection && this._model.data[e.id].state.checked && (n.className += " jstree-checked"), o = c.cloneNode(!1), this._model.data[e.id].state.checkbox_disabled && (o.className += " jstree-checkbox-disabled"), n.insertBefore(o, n.childNodes[0]))
                }
                return i || -1 === this.settings.checkbox.cascade.indexOf("undetermined") || (this._data.checkbox.uto && clearTimeout(this._data.checkbox.uto), this._data.checkbox.uto = setTimeout(S.proxy(this._undetermined, this), 50)), e
            }, this.show_checkboxes = function () {
                this._data.core.themes.checkboxes = !0, this.get_container_ul().removeClass("jstree-no-checkboxes")
            }, this.hide_checkboxes = function () {
                this._data.core.themes.checkboxes = !1, this.get_container_ul().addClass("jstree-no-checkboxes")
            }, this.toggle_checkboxes = function () {
                this._data.core.themes.checkboxes ? this.hide_checkboxes() : this.show_checkboxes()
            }, this.is_undetermined = function (e) {
                e = this.get_node(e);
                var t = this.settings.checkbox.cascade,
                    i, r, s = this.settings.checkbox.tie_selection,
                    a = this._data[s ? "core" : "checkbox"].selected,
                    n = this._model.data;
                if (!e || !0 === e.state[s ? "selected" : "checked"] || -1 === t.indexOf("undetermined") || -1 === t.indexOf("down") && -1 === t.indexOf("up")) return !1;
                if (!e.state.loaded && !0 === e.original.state.undetermined) return !0;
                for (i = 0, r = e.children_d.length; i < r; i++)
                    if (-1 !== S.inArray(e.children_d[i], a) || !n[e.children_d[i]].state.loaded && n[e.children_d[i]].original.state.undetermined) return !0;
                return !1
            }, this.disable_checkbox = function (e) {
                var t, i, r;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.disable_checkbox(e[t]);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                r = this.get_node(e, !0), e.state.checkbox_disabled || (e.state.checkbox_disabled = !0, r && r.length && r.children(".jstree-anchor").children(".jstree-checkbox").addClass("jstree-checkbox-disabled"), this.trigger("disable_checkbox", {
                    node: e
                }))
            }, this.enable_checkbox = function (e) {
                var t, i, r;
                if (S.isArray(e)) {
                    for (t = 0, i = (e = e.slice()).length; t < i; t++) this.enable_checkbox(e[t]);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                r = this.get_node(e, !0), e.state.checkbox_disabled && (e.state.checkbox_disabled = !1, r && r.length && r.children(".jstree-anchor").children(".jstree-checkbox").removeClass("jstree-checkbox-disabled"), this.trigger("enable_checkbox", {
                    node: e
                }))
            }, this.activate_node = function (e, t) {
                return !S(t.target).hasClass("jstree-checkbox-disabled") && (this.settings.checkbox.tie_selection && (this.settings.checkbox.whole_node || S(t.target).hasClass("jstree-checkbox")) && (t.ctrlKey = !0), this.settings.checkbox.tie_selection || !this.settings.checkbox.whole_node && !S(t.target).hasClass("jstree-checkbox") ? d.activate_node.call(this, e, t) : !this.is_disabled(e) && (this.is_checked(e) ? this.uncheck_node(e, t) : this.check_node(e, t), void this.trigger("activate_node", {
                    node: this.get_node(e)
                })))
            }, this._cascade_new_checked_state = function (e, t) {
                var i = this,
                    r = this.settings.checkbox.tie_selection,
                    s = this._model.data[e],
                    a = [],
                    n = [],
                    o, d, c;
                if (!this.settings.checkbox.cascade_to_disabled && s.state.disabled || !this.settings.checkbox.cascade_to_hidden && s.state.hidden) c = this.get_checked_descendants(e), s.state[r ? "selected" : "checked"] && c.push(s.id), a = a.concat(c);
                else {
                    if (s.children)
                        for (o = 0, d = s.children.length; o < d; o++) {
                            var l = s.children[o];
                            c = i._cascade_new_checked_state(l, t), a = a.concat(c), -1 < c.indexOf(l) && n.push(l)
                        }
                    var h = i.get_node(s, !0),
                        _ = 0 < n.length && n.length < s.children.length;
                    s.original && s.original.state && s.original.state.undetermined && (s.original.state.undetermined = _), _ ? (s.state[r ? "selected" : "checked"] = !1, h.attr("aria-selected", !1).children(".jstree-anchor").removeClass(r ? "jstree-clicked" : "jstree-checked")) : t && n.length === s.children.length ? (s.state[r ? "selected" : "checked"] = t, a.push(s.id), h.attr("aria-selected", !0).children(".jstree-anchor").addClass(r ? "jstree-clicked" : "jstree-checked")) : (s.state[r ? "selected" : "checked"] = !1, h.attr("aria-selected", !1).children(".jstree-anchor").removeClass(r ? "jstree-clicked" : "jstree-checked"))
                }
                return a
            }, this.get_checked_descendants = function (e) {
                var t = this,
                    i = t.settings.checkbox.tie_selection,
                    r;
                return t._model.data[e].children_d.filter(function (e) {
                    return t._model.data[e].state[i ? "selected" : "checked"]
                })
            }, this.check_node = function (e, t) {
                if (this.settings.checkbox.tie_selection) return this.select_node(e, !1, !0, t);
                var i, r, s, a;
                if (S.isArray(e)) {
                    for (r = 0, s = (e = e.slice()).length; r < s; r++) this.check_node(e[r], t);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                i = this.get_node(e, !0), e.state.checked || (e.state.checked = !0, this._data.checkbox.selected.push(e.id), i && i.length && i.children(".jstree-anchor").addClass("jstree-checked"), this.trigger("check_node", {
                    node: e,
                    selected: this._data.checkbox.selected,
                    event: t
                }))
            }, this.uncheck_node = function (e, t) {
                if (this.settings.checkbox.tie_selection) return this.deselect_node(e, !1, t);
                var i, r, s;
                if (S.isArray(e)) {
                    for (i = 0, r = (e = e.slice()).length; i < r; i++) this.uncheck_node(e[i], t);
                    return !0
                }
                if (!(e = this.get_node(e)) || e.id === S.jstree.root) return !1;
                s = this.get_node(e, !0), e.state.checked && (e.state.checked = !1, this._data.checkbox.selected = S.vakata.array_remove_item(this._data.checkbox.selected, e.id), s.length && s.children(".jstree-anchor").removeClass("jstree-checked"), this.trigger("uncheck_node", {
                    node: e,
                    selected: this._data.checkbox.selected,
                    event: t
                }))
            }, this.check_all = function () {
                if (this.settings.checkbox.tie_selection) return this.select_all();
                var e = this._data.checkbox.selected.concat([]),
                    t, i;
                for (this._data.checkbox.selected = this._model.data[S.jstree.root].children_d.concat(), t = 0, i = this._data.checkbox.selected.length; t < i; t++) this._model.data[this._data.checkbox.selected[t]] && (this._model.data[this._data.checkbox.selected[t]].state.checked = !0);
                this.redraw(!0), this.trigger("check_all", {
                    selected: this._data.checkbox.selected
                })
            }, this.uncheck_all = function () {
                if (this.settings.checkbox.tie_selection) return this.deselect_all();
                var e = this._data.checkbox.selected.concat([]),
                    t, i;
                for (t = 0, i = this._data.checkbox.selected.length; t < i; t++) this._model.data[this._data.checkbox.selected[t]] && (this._model.data[this._data.checkbox.selected[t]].state.checked = !1);
                this._data.checkbox.selected = [], this.element.find(".jstree-checked").removeClass("jstree-checked"), this.trigger("uncheck_all", {
                    selected: this._data.checkbox.selected,
                    node: e
                })
            }, this.is_checked = function (e) {
                return this.settings.checkbox.tie_selection ? this.is_selected(e) : !(!(e = this.get_node(e)) || e.id === S.jstree.root) && e.state.checked
            }, this.get_checked = function (e) {
                return this.settings.checkbox.tie_selection ? this.get_selected(e) : e ? S.map(this._data.checkbox.selected, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : this._data.checkbox.selected
            }, this.get_top_checked = function (e) {
                if (this.settings.checkbox.tie_selection) return this.get_top_selected(e);
                var t = this.get_checked(!0),
                    i = {},
                    r, s, a, n;
                for (r = 0, s = t.length; r < s; r++) i[t[r].id] = t[r];
                for (r = 0, s = t.length; r < s; r++)
                    for (a = 0, n = t[r].children_d.length; a < n; a++) i[t[r].children_d[a]] && delete i[t[r].children_d[a]];
                for (r in t = [], i) i.hasOwnProperty(r) && t.push(r);
                return e ? S.map(t, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : t
            }, this.get_bottom_checked = function (e) {
                if (this.settings.checkbox.tie_selection) return this.get_bottom_selected(e);
                var t = this.get_checked(!0),
                    i = [],
                    r, s;
                for (r = 0, s = t.length; r < s; r++) t[r].children.length || i.push(t[r].id);
                return e ? S.map(i, S.proxy(function (e) {
                    return this.get_node(e)
                }, this)) : i
            }, this.load_node = function (e, t) {
                var i, r, s, a, n, o;
                if (!S.isArray(e) && !this.settings.checkbox.tie_selection && (o = this.get_node(e)) && o.state.loaded)
                    for (i = 0, r = o.children_d.length; i < r; i++) this._model.data[o.children_d[i]].state.checked && (n = !0, this._data.checkbox.selected = S.vakata.array_remove_item(this._data.checkbox.selected, o.children_d[i]));
                return d.load_node.apply(this, arguments)
            }, this.get_state = function () {
                var e = d.get_state.apply(this, arguments);
                return this.settings.checkbox.tie_selection || (e.checkbox = this._data.checkbox.selected.slice()), e
            }, this.set_state = function (e, t) {
                var i = d.set_state.apply(this, arguments);
                if (i && e.checkbox) {
                    if (!this.settings.checkbox.tie_selection) {
                        this.uncheck_all();
                        var r = this;
                        S.each(e.checkbox, function (e, t) {
                            r.check_node(t)
                        })
                    }
                    return delete e.checkbox, this.set_state(e, t), !1
                }
                return i
            }, this.refresh = function (e, t) {
                return this.settings.checkbox.tie_selection && (this._data.checkbox.selected = []), d.refresh.apply(this, arguments)
            }
        }, S.jstree.defaults.conditionalselect = function () {
            return !0
        }, S.jstree.plugins.conditionalselect = function (e, i) {
            this.activate_node = function (e, t) {
                if (this.settings.conditionalselect.call(this, this.get_node(e), t)) return i.activate_node.call(this, e, t)
            }
        }, S.jstree.defaults.contextmenu = {
            select_node: !0,
            show_at_node: !0,
            items: function (e, t) {
                return {
                    create: {
                        separator_before: !1,
                        separator_after: !0,
                        _disabled: !1,
                        label: "Create",
                        action: function (e) {
                            var i = S.jstree.reference(e.reference),
                                t = i.get_node(e.reference);
                            i.create_node(t, {}, "last", function (t) {
                                try {
                                    i.edit(t)
                                } catch (e) {
                                    setTimeout(function () {
                                        i.edit(t)
                                    }, 0)
                                }
                            })
                        }
                    },
                    rename: {
                        separator_before: !1,
                        separator_after: !1,
                        _disabled: !1,
                        label: "Rename",
                        action: function (e) {
                            var t = S.jstree.reference(e.reference),
                                i = t.get_node(e.reference);
                            t.edit(i)
                        }
                    },
                    remove: {
                        separator_before: !1,
                        icon: !1,
                        separator_after: !1,
                        _disabled: !1,
                        label: "Delete",
                        action: function (e) {
                            var t = S.jstree.reference(e.reference),
                                i = t.get_node(e.reference);
                            t.is_selected(i) ? t.delete_node(t.get_selected()) : t.delete_node(i)
                        }
                    },
                    ccp: {
                        separator_before: !0,
                        icon: !1,
                        separator_after: !1,
                        label: "Edit",
                        action: !1,
                        submenu: {
                            cut: {
                                separator_before: !1,
                                separator_after: !1,
                                label: "Cut",
                                action: function (e) {
                                    var t = S.jstree.reference(e.reference),
                                        i = t.get_node(e.reference);
                                    t.is_selected(i) ? t.cut(t.get_top_selected()) : t.cut(i)
                                }
                            },
                            copy: {
                                separator_before: !1,
                                icon: !1,
                                separator_after: !1,
                                label: "Copy",
                                action: function (e) {
                                    var t = S.jstree.reference(e.reference),
                                        i = t.get_node(e.reference);
                                    t.is_selected(i) ? t.copy(t.get_top_selected()) : t.copy(i)
                                }
                            },
                            paste: {
                                separator_before: !1,
                                icon: !1,
                                _disabled: function (e) {
                                    return !S.jstree.reference(e.reference).can_paste()
                                },
                                separator_after: !1,
                                label: "Paste",
                                action: function (e) {
                                    var t = S.jstree.reference(e.reference),
                                        i = t.get_node(e.reference);
                                    t.paste(i)
                                }
                            }
                        }
                    }
                }
            }
        }, S.jstree.plugins.contextmenu = function (e, a) {
            this.bind = function () {
                a.bind.call(this);
                var i = 0,
                    r = null,
                    t, s;
                this.element.on("init.jstree loading.jstree ready.jstree", S.proxy(function () {
                    this.get_container_ul().addClass("jstree-contextmenu")
                }, this)).on("contextmenu.jstree", ".jstree-anchor", S.proxy(function (e, t) {
                    "input" !== e.target.tagName.toLowerCase() && (e.preventDefault(), i = e.ctrlKey ? +new Date : 0, (t || r) && (i = +new Date + 1e4), r && clearTimeout(r), this.is_loading(e.currentTarget) || this.show_contextmenu(e.currentTarget, e.pageX, e.pageY, e))
                }, this)).on("click.jstree", ".jstree-anchor", S.proxy(function (e) {
                    this._data.contextmenu.visible && (!i || 250 < +new Date - i) && S.vakata.context.hide(), i = 0
                }, this)).on("touchstart.jstree", ".jstree-anchor", function (e) {
                    e.originalEvent && e.originalEvent.changedTouches && e.originalEvent.changedTouches[0] && (t = e.originalEvent.changedTouches[0].clientX, s = e.originalEvent.changedTouches[0].clientY, r = setTimeout(function () {
                        S(e.currentTarget).trigger("contextmenu", !0)
                    }, 750))
                }).on("touchmove.vakata.jstree", function (e) {
                    r && e.originalEvent && e.originalEvent.changedTouches && e.originalEvent.changedTouches[0] && (10 < Math.abs(t - e.originalEvent.changedTouches[0].clientX) || 10 < Math.abs(s - e.originalEvent.changedTouches[0].clientY)) && (clearTimeout(r), S.vakata.context.hide())
                }).on("touchend.vakata.jstree", function (e) {
                    r && clearTimeout(r)
                }), S(k).on("context_hide.vakata.jstree", S.proxy(function (e, t) {
                    this._data.contextmenu.visible = !1, S(t.reference).removeClass("jstree-context")
                }, this))
            }, this.teardown = function () {
                this._data.contextmenu.visible && S.vakata.context.hide(), a.teardown.call(this)
            }, this.show_contextmenu = function (t, i, r, e) {
                if (!(t = this.get_node(t)) || t.id === S.jstree.root) return !1;
                var s = this.settings.contextmenu,
                    a, n = this.get_node(t, !0).children(".jstree-anchor"),
                    o = !1,
                    d = !1;
                (s.show_at_node || i === E || r === E) && (o = n.offset(), i = o.left, r = o.top + this._data.core.li_height), this.settings.contextmenu.select_node && !this.is_selected(t) && this.activate_node(t, e), d = s.items, S.isFunction(d) && (d = d.call(this, t, S.proxy(function (e) {
                    this._show_contextmenu(t, i, r, e)
                }, this))), S.isPlainObject(d) && this._show_contextmenu(t, i, r, d)
            }, this._show_contextmenu = function (e, t, i, r) {
                var s, a = this.get_node(e, !0).children(".jstree-anchor");
                S(k).one("context_show.vakata.jstree", S.proxy(function (e, t) {
                    var i = "jstree-contextmenu jstree-" + this.get_theme() + "-contextmenu";
                    S(t.element).addClass(i), a.addClass("jstree-context")
                }, this)), this._data.contextmenu.visible = !0, S.vakata.context.show(a, {
                    x: t,
                    y: i
                }, r), this.trigger("show_contextmenu", {
                    node: e,
                    x: t,
                    y: i
                })
            }
        }, g = {
            element: u = !1,
            reference: !1,
            position_x: 0,
            position_y: 0,
            items: [],
            html: "",
            is_visible: !1
        }, (_ = S).vakata.context = {
            settings: {
                hide_onmouseleave: 0,
                icons: !0
            },
            _trigger: function (e) {
                _(k).triggerHandler("context_" + e + ".vakata", {
                    reference: g.reference,
                    element: g.element,
                    position: {
                        x: g.position_x,
                        y: g.position_y
                    }
                })
            },
            _execute: function (e) {
                return !(!(e = g.items[e]) || e._disabled && (!_.isFunction(e._disabled) || e._disabled({
                    item: e,
                    reference: g.reference,
                    element: g.element
                })) || !e.action) && e.action.call(null, {
                    item: e,
                    reference: g.reference,
                    element: g.element,
                    position: {
                        x: g.position_x,
                        y: g.position_y
                    }
                })
            },
            _parse: function (e, t) {
                if (!e) return !1;
                t || (g.html = "", g.items = []);
                var i = "",
                    r = !1,
                    s;
                return t && (i += "<ul>"), _.each(e, function (e, t) {
                    if (!t) return !0;
                    g.items.push(t), !r && t.separator_before && (i += "<li class='vakata-context-separator'><a href='#' " + (_.vakata.context.settings.icons ? "" : 'style="margin-left:0px;"') + ">&#160;</a></li>"), r = !1, i += "<li class='" + (t._class || "") + (!0 === t._disabled || _.isFunction(t._disabled) && t._disabled({
                        item: t,
                        reference: g.reference,
                        element: g.element
                    }) ? " vakata-contextmenu-disabled " : "") + "' " + (t.shortcut ? " data-shortcut='" + t.shortcut + "' " : "") + ">", i += "<a href='#' rel='" + (g.items.length - 1) + "' " + (t.title ? "title='" + t.title + "'" : "") + ">", _.vakata.context.settings.icons && (i += "<i ", t.icon && (-1 !== t.icon.indexOf("/") || -1 !== t.icon.indexOf(".") ? i += " style='background:url(\"" + t.icon + "\") center center no-repeat' " : i += " class='" + t.icon + "' "), i += "></i><span class='vakata-contextmenu-sep'>&#160;</span>"), i += (_.isFunction(t.label) ? t.label({
                        item: e,
                        reference: g.reference,
                        element: g.element
                    }) : t.label) + (t.shortcut ? ' <span class="vakata-contextmenu-shortcut vakata-contextmenu-shortcut-' + t.shortcut + '">' + (t.shortcut_label || "") + "</span>" : "") + "</a>", t.submenu && (s = _.vakata.context._parse(t.submenu, !0)) && (i += s), i += "</li>", t.separator_after && (i += "<li class='vakata-context-separator'><a href='#' " + (_.vakata.context.settings.icons ? "" : 'style="margin-left:0px;"') + ">&#160;</a></li>", r = !0)
                }), i = i.replace(/<li class\='vakata-context-separator'\><\/li\>$/, ""), t && (i += "</ul>"), t || (g.html = i, _.vakata.context._trigger("parse")), 10 < i.length && i
            },
            _show_submenu: function (e) {
                if ((e = _(e)).length && e.children("ul").length) {
                    var t = e.children("ul"),
                        i = e.offset().left,
                        r = i + e.outerWidth(),
                        s = e.offset().top,
                        a = t.width(),
                        n = t.height(),
                        o = _(window).width() + _(window).scrollLeft(),
                        d = _(window).height() + _(window).scrollTop();
                    u ? e[r - (a + 10 + e.outerWidth()) < 0 ? "addClass" : "removeClass"]("vakata-context-left") : e[o < r + a && o - r < i ? "addClass" : "removeClass"]("vakata-context-right"), d < s + n + 10 && t.css("bottom", "-1px"), e.hasClass("vakata-context-right") ? i < a && t.css("margin-right", i - a) : o - r < a && t.css("margin-left", o - r - a), t.show()
                }
            },
            show: function (e, t, i) {
                var r, s, a, n, o, d, c, l, h = !0;
                switch (g.element && g.element.length && g.element.width(""), !0) {
                    case !t && !e:
                        return !1;
                    case !!t && !!e:
                        g.reference = e, g.position_x = t.x, g.position_y = t.y;
                        break;
                    case !t && !!e:
                        r = (g.reference = e).offset(), g.position_x = r.left + e.outerHeight(), g.position_y = r.top;
                        break;
                    case !!t && !e:
                        g.position_x = t.x, g.position_y = t.y
                }
                e && !i && _(e).data("vakata_contextmenu") && (i = _(e).data("vakata_contextmenu")), _.vakata.context._parse(i) && g.element.html(g.html), g.items.length && (g.element.appendTo(k.body), s = g.element, a = g.position_x, n = g.position_y, o = s.width(), d = s.height(), c = _(window).width() + _(window).scrollLeft(), l = _(window).height() + _(window).scrollTop(), u && (a -= s.outerWidth() - _(e).outerWidth()) < _(window).scrollLeft() + 20 && (a = _(window).scrollLeft() + 20), c < a + o + 20 && (a = c - (o + 20)), l < n + d + 20 && (n = l - (d + 20)), g.element.css({
                    left: a,
                    top: n
                }).show().find("a").first().focus().parent().addClass("vakata-context-hover"), g.is_visible = !0, _.vakata.context._trigger("show"))
            },
            hide: function () {
                g.is_visible && (g.element.hide().find("ul").hide().end().find(":focus").blur().end().detach(), g.is_visible = !1, _.vakata.context._trigger("hide"))
            }
        }, _(function () {
            u = "rtl" === _(k.body).css("direction");
            var i = !1;
            g.element = _("<ul class='vakata-context'></ul>"), g.element.on("mouseenter", "li", function (e) {
                e.stopImmediatePropagation(), _.contains(this, e.relatedTarget) || (i && clearTimeout(i), g.element.find(".vakata-context-hover").removeClass("vakata-context-hover").end(), _(this).siblings().find("ul").hide().end().end().parentsUntil(".vakata-context", "li").addBack().addClass("vakata-context-hover"), _.vakata.context._show_submenu(this))
            }).on("mouseleave", "li", function (e) {
                _.contains(this, e.relatedTarget) || _(this).find(".vakata-context-hover").addBack().removeClass("vakata-context-hover")
            }).on("mouseleave", function (e) {
                var t;
                _(this).find(".vakata-context-hover").removeClass("vakata-context-hover"), _.vakata.context.settings.hide_onmouseleave && (i = setTimeout((t = this, function () {
                    _.vakata.context.hide()
                }), _.vakata.context.settings.hide_onmouseleave))
            }).on("click", "a", function (e) {
                e.preventDefault(), _(this).blur().parent().hasClass("vakata-context-disabled") || !1 === _.vakata.context._execute(_(this).attr("rel")) || _.vakata.context.hide()
            }).on("keydown", "a", function (e) {
                var t = null;
                switch (e.which) {
                    case 13:
                    case 32:
                        e.type = "click", e.preventDefault(), _(e.currentTarget).trigger(e);
                        break;
                    case 37:
                        g.is_visible && (g.element.find(".vakata-context-hover").last().closest("li").first().find("ul").hide().find(".vakata-context-hover").removeClass("vakata-context-hover").end().end().children("a").focus(), e.stopImmediatePropagation(), e.preventDefault());
                        break;
                    case 38:
                        g.is_visible && ((t = g.element.find("ul:visible").addBack().last().children(".vakata-context-hover").removeClass("vakata-context-hover").prevAll("li:not(.vakata-context-separator)").first()).length || (t = g.element.find("ul:visible").addBack().last().children("li:not(.vakata-context-separator)").last()), t.addClass("vakata-context-hover").children("a").focus(), e.stopImmediatePropagation(), e.preventDefault());
                        break;
                    case 39:
                        g.is_visible && (g.element.find(".vakata-context-hover").last().children("ul").show().children("li:not(.vakata-context-separator)").removeClass("vakata-context-hover").first().addClass("vakata-context-hover").children("a").focus(), e.stopImmediatePropagation(), e.preventDefault());
                        break;
                    case 40:
                        g.is_visible && ((t = g.element.find("ul:visible").addBack().last().children(".vakata-context-hover").removeClass("vakata-context-hover").nextAll("li:not(.vakata-context-separator)").first()).length || (t = g.element.find("ul:visible").addBack().last().children("li:not(.vakata-context-separator)").first()), t.addClass("vakata-context-hover").children("a").focus(), e.stopImmediatePropagation(), e.preventDefault());
                        break;
                    case 27:
                        _.vakata.context.hide(), e.preventDefault()
                }
            }).on("keydown", function (e) {
                e.preventDefault();
                var t = g.element.find(".vakata-contextmenu-shortcut-" + e.which).parent();
                t.parent().not(".vakata-context-disabled") && t.click()
            }), _(k).on("mousedown.vakata.jstree", function (e) {
                g.is_visible && g.element[0] !== e.target && !_.contains(g.element[0], e.target) && _.vakata.context.hide()
            }).on("context_show.vakata.jstree", function (e, t) {
                g.element.find("li:has(ul)").children("a").addClass("vakata-context-parent"), u && g.element.addClass("vakata-context-rtl").css("direction", "rtl"), g.element.find("ul").hide().end()
            })
        }), S.jstree.defaults.dnd = {
            copy: !0,
            open_timeout: 500,
            is_draggable: !0,
            check_while_dragging: !0,
            always_copy: !1,
            inside_pos: 0,
            drag_selection: !0,
            touch: !0,
            large_drop_target: !1,
            large_drag_target: !1,
            use_html5: !1
        }, S.jstree.plugins.dnd = function (e, o) {
            this.init = function (e, t) {
                o.init.call(this, e, t), this.settings.dnd.use_html5 = this.settings.dnd.use_html5 && "draggable" in k.createElement("span")
            }, this.bind = function () {
                o.bind.call(this), this.element.on(this.settings.dnd.use_html5 ? "dragstart.jstree" : "mousedown.jstree touchstart.jstree", this.settings.dnd.large_drag_target ? ".jstree-node" : ".jstree-anchor", S.proxy(function (e) {
                    if (this.settings.dnd.large_drag_target && S(e.target).closest(".jstree-node")[0] !== e.currentTarget) return !0;
                    if ("touchstart" === e.type && (!this.settings.dnd.touch || "selected" === this.settings.dnd.touch && !S(e.currentTarget).closest(".jstree-node").children(".jstree-anchor").hasClass("jstree-clicked"))) return !0;
                    var t = this.get_node(e.target),
                        i = this.is_selected(t) && this.settings.dnd.drag_selection ? this.get_top_selected().length : 1,
                        r = 1 < i ? i + " " + this.get_string("nodes") : this.get_text(e.currentTarget);
                    if (this.settings.core.force_text && (r = S.vakata.html.escape(r)), t && t.id && t.id !== S.jstree.root && (1 === e.which || "touchstart" === e.type || "dragstart" === e.type) && (!0 === this.settings.dnd.is_draggable || S.isFunction(this.settings.dnd.is_draggable) && this.settings.dnd.is_draggable.call(this, 1 < i ? this.get_top_selected(!0) : [t], e))) {
                        if (d = {
                            jstree: !0,
                            origin: this,
                            obj: this.get_node(t, !0),
                            nodes: 1 < i ? this.get_top_selected() : [t.id]
                        }, l = e.currentTarget, !this.settings.dnd.use_html5) return this.element.trigger("mousedown.jstree"), S.vakata.dnd.start(e, d, '<div id="jstree-dnd" class="jstree-' + this.get_theme() + " jstree-" + this.get_theme() + "-" + this.get_theme_variant() + " " + (this.settings.core.themes.responsive ? " jstree-dnd-responsive" : "") + '"><i class="jstree-icon jstree-er"></i>' + r + '<ins class="jstree-copy" style="display:none;">+</ins></div>');
                        S.vakata.dnd._trigger("start", e, {
                            helper: S(),
                            element: l,
                            data: d
                        })
                    }
                }, this)), this.settings.dnd.use_html5 && this.element.on("dragover.jstree", function (e) {
                    return e.preventDefault(), S.vakata.dnd._trigger("move", e, {
                        helper: S(),
                        element: l,
                        data: d
                    }), !1
                }).on("drop.jstree", S.proxy(function (e) {
                    return e.preventDefault(), S.vakata.dnd._trigger("stop", e, {
                        helper: S(),
                        element: l,
                        data: d
                    }), !1
                }, this))
            }, this.redraw_node = function (e, t, i, r) {
                if ((e = o.redraw_node.apply(this, arguments)) && this.settings.dnd.use_html5)
                    if (this.settings.dnd.large_drag_target) e.setAttribute("draggable", !0);
                    else {
                        var s, a, n = null;
                        for (s = 0, a = e.childNodes.length; s < a; s++)
                            if (e.childNodes[s] && e.childNodes[s].className && -1 !== e.childNodes[s].className.indexOf("jstree-anchor")) {
                                n = e.childNodes[s];
                                break
                            }
                        n && n.setAttribute("draggable", !0)
                    }
                return e
            }
        }, S(function () {
            var C = !1,
                A = !1,
                T = !1,
                N = !1,
                O = S('<div id="jstree-marker">&#160;</div>').hide();
            S(k).on("dragover.vakata.jstree", function (e) {
                l && S.vakata.dnd._trigger("move", e, {
                    helper: S(),
                    element: l,
                    data: d
                })
            }).on("drop.vakata.jstree", function (e) {
                l && (S.vakata.dnd._trigger("stop", e, {
                    helper: S(),
                    element: l,
                    data: d
                }), d = l = null)
            }).on("dnd_start.vakata.jstree", function (e, t) {
                T = C = !1, t && t.data && t.data.jstree && O.appendTo(k.body)
            }).on("dnd_move.vakata.jstree", function (e, s) {
                var a = s.event.target !== T.target;
                if (N && (s.event && "dragover" === s.event.type && !a || clearTimeout(N)), s && s.data && s.data.jstree && (!s.event.target.id || "jstree-marker" !== s.event.target.id)) {
                    T = s.event;
                    var n = S.jstree.reference(s.event.target),
                        o = !1,
                        d = !1,
                        t = !1,
                        i, c, l, h, _, u, g, f, p, m, v, j, y, k, x, b, w;
                    if (n && n._data && n._data.dnd)
                        if (O.attr("class", "jstree-" + n.get_theme() + (n.settings.core.themes.responsive ? " jstree-dnd-responsive" : "")), b = s.data.origin && (s.data.origin.settings.dnd.always_copy || s.data.origin.settings.dnd.copy && (s.event.metaKey || s.event.ctrlKey)), s.helper.children().attr("class", "jstree-" + n.get_theme() + " jstree-" + n.get_theme() + "-" + n.get_theme_variant() + " " + (n.settings.core.themes.responsive ? " jstree-dnd-responsive" : "")).find(".jstree-copy").first()[b ? "show" : "hide"](), s.event.target !== n.element[0] && s.event.target !== n.get_container_ul()[0] || 0 !== n.get_container_ul().children().length) {
                            if ((o = n.settings.dnd.large_drop_target ? S(s.event.target).closest(".jstree-node").children(".jstree-anchor") : S(s.event.target).closest(".jstree-anchor")) && o.length && o.parent().is(".jstree-closed, .jstree-open, .jstree-leaf") && (d = o.offset(), t = (s.event.pageY !== E ? s.event.pageY : s.event.originalEvent.pageY) - d.top, h = o.outerHeight(), g = t < h / 3 ? ["b", "i", "a"] : h - h / 3 < t ? ["a", "i", "b"] : h / 2 < t ? ["i", "a", "b"] : ["i", "b", "a"], S.each(g, function (e, t) {
                                switch (t) {
                                    case "b":
                                        c = d.left - 6, l = d.top, _ = n.get_parent(o), u = o.parent().index();
                                        break;
                                    case "i":
                                        k = n.settings.dnd.inside_pos, x = n.get_node(o.parent()), c = d.left - 2, l = d.top + h / 2 + 1, _ = x.id, u = "first" === k ? 0 : "last" === k ? x.children.length : Math.min(k, x.children.length);
                                        break;
                                    case "a":
                                        c = d.left - 6, l = d.top + h, _ = n.get_parent(o), u = o.parent().index() + 1
                                }
                                for (f = !0, p = 0, m = s.data.nodes.length; p < m; p++)
                                    if (v = s.data.origin && (s.data.origin.settings.dnd.always_copy || s.data.origin.settings.dnd.copy && (s.event.metaKey || s.event.ctrlKey)) ? "copy_node" : "move_node", j = u, "move_node" === v && "a" === t && s.data.origin && s.data.origin === n && _ === n.get_parent(s.data.nodes[p]) && (y = n.get_node(_), j > S.inArray(s.data.nodes[p], y.children) && (j -= 1)), !(f = f && (n && n.settings && n.settings.dnd && !1 === n.settings.dnd.check_while_dragging || n.check(v, s.data.origin && s.data.origin !== n ? s.data.origin.get_node(s.data.nodes[p]) : s.data.nodes[p], _, j, {
                                        dnd: !0,
                                        ref: n.get_node(o.parent()),
                                        pos: t,
                                        origin: s.data.origin,
                                        is_multi: s.data.origin && s.data.origin !== n,
                                        is_foreign: !s.data.origin
                                    })))) {
                                        n && n.last_error && (A = n.last_error());
                                        break
                                    }
                                var i, r;
                                if ("i" === t && o.parent().is(".jstree-closed") && n.settings.dnd.open_timeout && (s.event && "dragover" === s.event.type && !a || (N && clearTimeout(N), N = setTimeout((i = n, r = o, function () {
                                    i.open_node(r)
                                }), n.settings.dnd.open_timeout))), f) return (w = n.get_node(_, !0)).hasClass(".jstree-dnd-parent") || (S(".jstree-dnd-parent").removeClass("jstree-dnd-parent"), w.addClass("jstree-dnd-parent")), C = {
                                    ins: n,
                                    par: _,
                                    pos: "i" !== t || "last" !== k || 0 !== u || n.is_loaded(x) ? u : "last"
                                }, O.css({
                                    left: c + "px",
                                    top: l + "px"
                                }).show(), s.helper.find(".jstree-icon").first().removeClass("jstree-er").addClass("jstree-ok"), s.event.originalEvent && s.event.originalEvent.dataTransfer && (s.event.originalEvent.dataTransfer.dropEffect = b ? "copy" : "move"), A = {}, !(g = !0)
                            }), !0 === g)) return
                        } else {
                            for (f = !0, p = 0, m = s.data.nodes.length; p < m; p++)
                                if (!(f = f && n.check(s.data.origin && (s.data.origin.settings.dnd.always_copy || s.data.origin.settings.dnd.copy && (s.event.metaKey || s.event.ctrlKey)) ? "copy_node" : "move_node", s.data.origin && s.data.origin !== n ? s.data.origin.get_node(s.data.nodes[p]) : s.data.nodes[p], S.jstree.root, "last", {
                                    dnd: !0,
                                    ref: n.get_node(S.jstree.root),
                                    pos: "i",
                                    origin: s.data.origin,
                                    is_multi: s.data.origin && s.data.origin !== n,
                                    is_foreign: !s.data.origin
                                }))) break;
                            if (f) return C = {
                                ins: n,
                                par: S.jstree.root,
                                pos: "last"
                            }, O.hide(), s.helper.find(".jstree-icon").first().removeClass("jstree-er").addClass("jstree-ok"), void (s.event.originalEvent && s.event.originalEvent.dataTransfer && (s.event.originalEvent.dataTransfer.dropEffect = b ? "copy" : "move"))
                        }
                    S(".jstree-dnd-parent").removeClass("jstree-dnd-parent"), C = !1, s.helper.find(".jstree-icon").removeClass("jstree-ok").addClass("jstree-er"), s.event.originalEvent && s.event.originalEvent.dataTransfer, O.hide()
                }
            }).on("dnd_scroll.vakata.jstree", function (e, t) {
                t && t.data && t.data.jstree && (O.hide(), T = C = !1, t.helper.find(".jstree-icon").first().removeClass("jstree-ok").addClass("jstree-er"))
            }).on("dnd_stop.vakata.jstree", function (e, t) {
                if (S(".jstree-dnd-parent").removeClass("jstree-dnd-parent"), N && clearTimeout(N), t && t.data && t.data.jstree) {
                    O.hide().detach();
                    var i, r, s = [];
                    if (C) {
                        for (i = 0, r = t.data.nodes.length; i < r; i++) s[i] = t.data.origin ? t.data.origin.get_node(t.data.nodes[i]) : t.data.nodes[i];
                        C.ins[t.data.origin && (t.data.origin.settings.dnd.always_copy || t.data.origin.settings.dnd.copy && (t.event.metaKey || t.event.ctrlKey)) ? "copy_node" : "move_node"](s, C.par, C.pos, !1, !1, !1, t.data.origin)
                    } else (i = S(t.event.target).closest(".jstree")).length && A && A.error && "check" === A.error && (i = i.jstree(!0)) && i.settings.core.error.call(this, A);
                    C = T = !1
                }
            }).on("keyup.jstree keydown.jstree", function (e, t) {
                (t = S.vakata.dnd._get()) && t.data && t.data.jstree && ("keyup" === e.type && 27 === e.which ? (N && clearTimeout(N), N = T = A = C = !1, O.hide().detach(), S.vakata.dnd._clean()) : (t.helper.find(".jstree-copy").first()[t.data.origin && (t.data.origin.settings.dnd.always_copy || t.data.origin.settings.dnd.copy && (e.metaKey || e.ctrlKey)) ? "show" : "hide"](), T && (T.metaKey = e.metaKey, T.ctrlKey = e.ctrlKey, S.vakata.dnd._trigger("move", T))))
            })
        }), f = {
            element: !((h = S).vakata.html = {
                div: h("<div />"),
                escape: function (e) {
                    return h.vakata.html.div.text(e).html()
                },
                strip: function (e) {
                    return h.vakata.html.div.empty().append(h.parseHTML(e)).text()
                }
            }),
            target: !1,
            is_down: !1,
            is_drag: !1,
            helper: !1,
            helper_w: 0,
            data: !1,
            init_x: 0,
            init_y: 0,
            scroll_l: 0,
            scroll_t: 0,
            scroll_e: !1,
            scroll_i: !1,
            is_touch: !1
        }, h.vakata.dnd = {
            settings: {
                scroll_speed: 10,
                scroll_proximity: 20,
                helper_left: 5,
                helper_top: 10,
                threshold: 5,
                threshold_touch: 10
            },
            _trigger: function (e, t, i) {
                i === E && (i = h.vakata.dnd._get()), i.event = t, h(k).triggerHandler("dnd_" + e + ".vakata", i)
            },
            _get: function () {
                return {
                    data: f.data,
                    element: f.element,
                    helper: f.helper
                }
            },
            _clean: function () {
                f.helper && f.helper.remove(), f.scroll_i && (clearInterval(f.scroll_i), f.scroll_i = !1), f = {
                    element: !1,
                    target: !1,
                    is_down: !1,
                    is_drag: !1,
                    helper: !1,
                    helper_w: 0,
                    data: !1,
                    init_x: 0,
                    init_y: 0,
                    scroll_l: 0,
                    scroll_t: 0,
                    scroll_e: !1,
                    scroll_i: !1,
                    is_touch: !1
                }, h(k).off("mousemove.vakata.jstree touchmove.vakata.jstree", h.vakata.dnd.drag), h(k).off("mouseup.vakata.jstree touchend.vakata.jstree", h.vakata.dnd.stop)
            },
            _scroll: function (e) {
                if (!f.scroll_e || !f.scroll_l && !f.scroll_t) return f.scroll_i && (clearInterval(f.scroll_i), f.scroll_i = !1), !1;
                if (!f.scroll_i) return f.scroll_i = setInterval(h.vakata.dnd._scroll, 100), !1;
                if (!0 === e) return !1;
                var t = f.scroll_e.scrollTop(),
                    i = f.scroll_e.scrollLeft();
                f.scroll_e.scrollTop(t + f.scroll_t * h.vakata.dnd.settings.scroll_speed), f.scroll_e.scrollLeft(i + f.scroll_l * h.vakata.dnd.settings.scroll_speed), t === f.scroll_e.scrollTop() && i === f.scroll_e.scrollLeft() || h.vakata.dnd._trigger("scroll", f.scroll_e)
            },
            start: function (e, t, i) {
                "touchstart" === e.type && e.originalEvent && e.originalEvent.changedTouches && e.originalEvent.changedTouches[0] && (e.pageX = e.originalEvent.changedTouches[0].pageX, e.pageY = e.originalEvent.changedTouches[0].pageY, e.target = k.elementFromPoint(e.originalEvent.changedTouches[0].pageX - window.pageXOffset, e.originalEvent.changedTouches[0].pageY - window.pageYOffset)), f.is_drag && h.vakata.dnd.stop({});
                try {
                    e.currentTarget.unselectable = "on", e.currentTarget.onselectstart = function () {
                        return !1
                    }, e.currentTarget.style && (e.currentTarget.style.touchAction = "none", e.currentTarget.style.msTouchAction = "none", e.currentTarget.style.MozUserSelect = "none")
                } catch (e) { }
                return f.init_x = e.pageX, f.init_y = e.pageY, f.data = t, f.is_down = !0, f.element = e.currentTarget, f.target = e.target, f.is_touch = "touchstart" === e.type, !1 !== i && (f.helper = h("<div id='vakata-dnd'></div>").html(i).css({
                    display: "block",
                    margin: "0",
                    padding: "0",
                    position: "absolute",
                    top: "-2000px",
                    lineHeight: "16px",
                    zIndex: "10000"
                })), h(k).on("mousemove.vakata.jstree touchmove.vakata.jstree", h.vakata.dnd.drag), h(k).on("mouseup.vakata.jstree touchend.vakata.jstree", h.vakata.dnd.stop), !1
            },
            drag: function (i) {
                if ("touchmove" === i.type && i.originalEvent && i.originalEvent.changedTouches && i.originalEvent.changedTouches[0] && (i.pageX = i.originalEvent.changedTouches[0].pageX, i.pageY = i.originalEvent.changedTouches[0].pageY, i.target = k.elementFromPoint(i.originalEvent.changedTouches[0].pageX - window.pageXOffset, i.originalEvent.changedTouches[0].pageY - window.pageYOffset)), f.is_down) {
                    if (!f.is_drag) {
                        if (!(Math.abs(i.pageX - f.init_x) > (f.is_touch ? h.vakata.dnd.settings.threshold_touch : h.vakata.dnd.settings.threshold) || Math.abs(i.pageY - f.init_y) > (f.is_touch ? h.vakata.dnd.settings.threshold_touch : h.vakata.dnd.settings.threshold))) return;
                        f.helper && (f.helper.appendTo(k.body), f.helper_w = f.helper.outerWidth()), f.is_drag = !0, h(f.target).one("click.vakata", !1), h.vakata.dnd._trigger("start", i)
                    }
                    var e = !1,
                        t = !1,
                        r = !1,
                        s = !1,
                        a = !1,
                        n = !1,
                        o = !1,
                        d = !1,
                        c = !1,
                        l = !1;
                    return f.scroll_t = 0, f.scroll_l = 0, f.scroll_e = !1, h(h(i.target).parentsUntil("body").addBack().get().reverse()).filter(function () {
                        return /^auto|scroll$/.test(h(this).css("overflow")) && (this.scrollHeight > this.offsetHeight || this.scrollWidth > this.offsetWidth)
                    }).each(function () {
                        var e = h(this),
                            t = e.offset();
                        if (this.scrollHeight > this.offsetHeight && (t.top + e.height() - i.pageY < h.vakata.dnd.settings.scroll_proximity && (f.scroll_t = 1), i.pageY - t.top < h.vakata.dnd.settings.scroll_proximity && (f.scroll_t = -1)), this.scrollWidth > this.offsetWidth && (t.left + e.width() - i.pageX < h.vakata.dnd.settings.scroll_proximity && (f.scroll_l = 1), i.pageX - t.left < h.vakata.dnd.settings.scroll_proximity && (f.scroll_l = -1)), f.scroll_t || f.scroll_l) return f.scroll_e = h(this), !1
                    }), f.scroll_e || (e = h(k), t = h(window), r = e.height(), s = t.height(), a = e.width(), n = t.width(), o = e.scrollTop(), d = e.scrollLeft(), s < r && i.pageY - o < h.vakata.dnd.settings.scroll_proximity && (f.scroll_t = -1), s < r && s - (i.pageY - o) < h.vakata.dnd.settings.scroll_proximity && (f.scroll_t = 1), n < a && i.pageX - d < h.vakata.dnd.settings.scroll_proximity && (f.scroll_l = -1), n < a && n - (i.pageX - d) < h.vakata.dnd.settings.scroll_proximity && (f.scroll_l = 1), (f.scroll_t || f.scroll_l) && (f.scroll_e = e)), f.scroll_e && h.vakata.dnd._scroll(!0), f.helper && (c = parseInt(i.pageY + h.vakata.dnd.settings.helper_top, 10), l = parseInt(i.pageX + h.vakata.dnd.settings.helper_left, 10), r && r < c + 25 && (c = r - 50), a && l + f.helper_w > a && (l = a - (f.helper_w + 2)), f.helper.css({
                        left: l + "px",
                        top: c + "px"
                    })), h.vakata.dnd._trigger("move", i), !1
                }
            },
            stop: function (e) {
                if ("touchend" === e.type && e.originalEvent && e.originalEvent.changedTouches && e.originalEvent.changedTouches[0] && (e.pageX = e.originalEvent.changedTouches[0].pageX, e.pageY = e.originalEvent.changedTouches[0].pageY, e.target = k.elementFromPoint(e.originalEvent.changedTouches[0].pageX - window.pageXOffset, e.originalEvent.changedTouches[0].pageY - window.pageYOffset)), f.is_drag) e.target !== f.target && h(f.target).off("click.vakata"), h.vakata.dnd._trigger("stop", e);
                else if ("touchend" === e.type && e.target === f.target) {
                    var t = setTimeout(function () {
                        h(e.target).click()
                    }, 100);
                    h(e.target).one("click", function () {
                        t && clearTimeout(t)
                    })
                }
                return h.vakata.dnd._clean(), !1
            }
        }, S.jstree.defaults.massload = null, S.jstree.plugins.massload = function (e, h) {
            this.init = function (e, t) {
                this._data.massload = {}, h.init.call(this, e, t)
            }, this._load_nodes = function (a, n, o, d) {
                var e = this.settings.massload,
                    t = JSON.stringify(a),
                    i = [],
                    r = this._model.data,
                    s, c, l;
                if (!o) {
                    for (s = 0, c = a.length; s < c; s++) r[a[s]] && (r[a[s]].state.loaded || r[a[s]].state.failed) && !d || (i.push(a[s]), (l = this.get_node(a[s], !0)) && l.length && l.addClass("jstree-loading").attr("aria-busy", !0));
                    if (this._data.massload = {}, i.length) {
                        if (S.isFunction(e)) return e.call(this, i, S.proxy(function (e) {
                            var t, i;
                            if (e)
                                for (t in e) e.hasOwnProperty(t) && (this._data.massload[t] = e[t]);
                            for (t = 0, i = a.length; t < i; t++)(l = this.get_node(a[t], !0)) && l.length && l.removeClass("jstree-loading").attr("aria-busy", !1);
                            h._load_nodes.call(this, a, n, o, d)
                        }, this));
                        if ("object" == typeof e && e && e.url) return e = S.extend(!0, {}, e), S.isFunction(e.url) && (e.url = e.url.call(this, i)), S.isFunction(e.data) && (e.data = e.data.call(this, i)), S.ajax(e).done(S.proxy(function (e, t, i) {
                            var r, s;
                            if (e)
                                for (r in e) e.hasOwnProperty(r) && (this._data.massload[r] = e[r]);
                            for (r = 0, s = a.length; r < s; r++)(l = this.get_node(a[r], !0)) && l.length && l.removeClass("jstree-loading").attr("aria-busy", !1);
                            h._load_nodes.call(this, a, n, o, d)
                        }, this)).fail(S.proxy(function (e) {
                            h._load_nodes.call(this, a, n, o, d)
                        }, this))
                    }
                }
                return h._load_nodes.call(this, a, n, o, d)
            }, this._load_node = function (e, t) {
                var i = this._data.massload[e.id],
                    r = null,
                    s;
                return i ? (r = this["string" == typeof i ? "_append_html_data" : "_append_json_data"](e, "string" == typeof i ? S(S.parseHTML(i)).filter(function () {
                    return 3 !== this.nodeType
                }) : i, function (e) {
                    t.call(this, e)
                }), (s = this.get_node(e.id, !0)) && s.length && s.removeClass("jstree-loading").attr("aria-busy", !1), delete this._data.massload[e.id], r) : h._load_node.call(this, e, t)
            }
        }, S.jstree.defaults.search = {
            ajax: !1,
            fuzzy: !1,
            case_sensitive: !1,
            show_only_matches: !1,
            show_only_matches_children: !1,
            close_opened_onclear: !0,
            search_leaves_only: !1,
            search_callback: !1
        }, S.jstree.plugins.search = function (e, o) {
            this.bind = function () {
                o.bind.call(this), this._data.search.str = "", this._data.search.dom = S(), this._data.search.res = [], this._data.search.opn = [], this._data.search.som = !1, this._data.search.smc = !1, this._data.search.hdn = [], this.element.on("search.jstree", S.proxy(function (e, t) {
                    if (this._data.search.som && t.res.length) {
                        var i = this._model.data,
                            r, s, a = [],
                            n, o;
                        for (r = 0, s = t.res.length; r < s; r++)
                            if (i[t.res[r]] && !i[t.res[r]].state.hidden && (a.push(t.res[r]), a = a.concat(i[t.res[r]].parents), this._data.search.smc))
                                for (n = 0, o = i[t.res[r]].children_d.length; n < o; n++) i[i[t.res[r]].children_d[n]] && !i[i[t.res[r]].children_d[n]].state.hidden && a.push(i[t.res[r]].children_d[n]);
                        a = S.vakata.array_remove_item(S.vakata.array_unique(a), S.jstree.root), this._data.search.hdn = this.hide_all(!0), this.show_node(a, !0), this.redraw(!0)
                    }
                }, this)).on("clear_search.jstree", S.proxy(function (e, t) {
                    this._data.search.som && t.res.length && (this.show_node(this._data.search.hdn, !0), this.redraw(!0))
                }, this))
            }, this.search = function (r, e, t, i, s, a) {
                if (!1 === r || "" === S.trim(r.toString())) return this.clear_search();
                i = (i = this.get_node(i)) && i.id ? i.id : null, r = r.toString();
                var n = this.settings.search,
                    o = !!n.ajax && n.ajax,
                    d = this._model.data,
                    c = null,
                    l = [],
                    h = [],
                    _, u;
                if (this._data.search.res.length && !s && this.clear_search(), t === E && (t = n.show_only_matches), a === E && (a = n.show_only_matches_children), !e && !1 !== o) return S.isFunction(o) ? o.call(this, r, S.proxy(function (e) {
                    e && e.d && (e = e.d), this._load_nodes(S.isArray(e) ? S.vakata.array_unique(e) : [], function () {
                        this.search(r, !0, t, i, s, a)
                    })
                }, this), i) : ((o = S.extend({}, o)).data || (o.data = {}), o.data.str = r, i && (o.data.inside = i), this._data.search.lastRequest && this._data.search.lastRequest.abort(), this._data.search.lastRequest = S.ajax(o).fail(S.proxy(function () {
                    this._data.core.last_error = {
                        error: "ajax",
                        plugin: "search",
                        id: "search_01",
                        reason: "Could not load search parents",
                        data: JSON.stringify(o)
                    }, this.settings.core.error.call(this, this._data.core.last_error)
                }, this)).done(S.proxy(function (e) {
                    e && e.d && (e = e.d), this._load_nodes(S.isArray(e) ? S.vakata.array_unique(e) : [], function () {
                        this.search(r, !0, t, i, s, a)
                    })
                }, this)), this._data.search.lastRequest);
                if (s || (this._data.search.str = r, this._data.search.dom = S(), this._data.search.res = [], this._data.search.opn = [], this._data.search.som = t, this._data.search.smc = a), c = new S.vakata.search(r, !0, {
                    caseSensitive: n.case_sensitive,
                    fuzzy: n.fuzzy
                }), S.each(d[i || S.jstree.root].children_d, function (e, t) {
                    var i = d[t];
                    i.text && !i.state.hidden && (!n.search_leaves_only || i.state.loaded && 0 === i.children.length) && (n.search_callback && n.search_callback.call(this, r, i) || !n.search_callback && c.search(i.text).isMatch) && (l.push(t), h = h.concat(i.parents))
                }), l.length) {
                    for (_ = 0, u = (h = S.vakata.array_unique(h)).length; _ < u; _++) h[_] !== S.jstree.root && d[h[_]] && !0 === this.open_node(h[_], null, 0) && this._data.search.opn.push(h[_]);
                    this._data.search.res = s ? (this._data.search.dom = this._data.search.dom.add(S(this.element[0].querySelectorAll("#" + S.map(l, function (e) {
                        return -1 !== "0123456789".indexOf(e[0]) ? "\\3" + e[0] + " " + e.substr(1).replace(S.jstree.idregex, "\\$&") : e.replace(S.jstree.idregex, "\\$&")
                    }).join(", #")))), S.vakata.array_unique(this._data.search.res.concat(l))) : (this._data.search.dom = S(this.element[0].querySelectorAll("#" + S.map(l, function (e) {
                        return -1 !== "0123456789".indexOf(e[0]) ? "\\3" + e[0] + " " + e.substr(1).replace(S.jstree.idregex, "\\$&") : e.replace(S.jstree.idregex, "\\$&")
                    }).join(", #"))), l), this._data.search.dom.children(".jstree-anchor").addClass("jstree-search")
                }
                this.trigger("search", {
                    nodes: this._data.search.dom,
                    str: r,
                    res: this._data.search.res,
                    show_only_matches: t
                })
            }, this.clear_search = function () {
                this.settings.search.close_opened_onclear && this.close_node(this._data.search.opn, 0), this.trigger("clear_search", {
                    nodes: this._data.search.dom,
                    str: this._data.search.str,
                    res: this._data.search.res
                }), this._data.search.res.length && (this._data.search.dom = S(this.element[0].querySelectorAll("#" + S.map(this._data.search.res, function (e) {
                    return -1 !== "0123456789".indexOf(e[0]) ? "\\3" + e[0] + " " + e.substr(1).replace(S.jstree.idregex, "\\$&") : e.replace(S.jstree.idregex, "\\$&")
                }).join(", #"))), this._data.search.dom.children(".jstree-anchor").removeClass("jstree-search")), this._data.search.str = "", this._data.search.res = [], this._data.search.opn = [], this._data.search.dom = S()
            }, this.redraw_node = function (e, t, i, r) {
                if ((e = o.redraw_node.apply(this, arguments)) && -1 !== S.inArray(e.id, this._data.search.res)) {
                    var s, a, n = null;
                    for (s = 0, a = e.childNodes.length; s < a; s++)
                        if (e.childNodes[s] && e.childNodes[s].className && -1 !== e.childNodes[s].className.indexOf("jstree-anchor")) {
                            n = e.childNodes[s];
                            break
                        }
                    n && (n.className += " jstree-search")
                }
                return e
            }
        }, (i = S).vakata.search = function (p, e, m) {
            m = m || {}, !1 !== (m = i.extend({}, i.vakata.search.defaults, m)).fuzzy && (m.fuzzy = !0), p = m.caseSensitive ? p : p.toLowerCase();
            var v = m.location,
                s = m.distance,
                j = m.threshold,
                y = p.length,
                k, x, b, t;
            return 32 < y && (m.fuzzy = !1), m.fuzzy && (k = 1 << y - 1, x = function () {
                var e = {},
                    t = 0;
                for (t = 0; t < y; t++) e[p.charAt(t)] = 0;
                for (t = 0; t < y; t++) e[p.charAt(t)] |= 1 << y - t - 1;
                return e
            }(), b = function (e, t) {
                var i = e / y,
                    r = Math.abs(v - t);
                return s ? i + r / s : r ? 1 : i
            }), t = function (e) {
                if (e = m.caseSensitive ? e : e.toLowerCase(), p === e || -1 !== e.indexOf(p)) return {
                    isMatch: !0,
                    score: 0
                };
                if (!m.fuzzy) return {
                    isMatch: !1,
                    score: 1
                };
                var t, i, r = e.length,
                    s = j,
                    a = e.indexOf(p, v),
                    n, o, d = y + r,
                    c, l, h, _, u, g = 1,
                    f = [];
                for (-1 !== a && (s = Math.min(b(0, a), s), -1 !== (a = e.lastIndexOf(p, v + y)) && (s = Math.min(b(0, a), s))), a = -1, t = 0; t < y; t++) {
                    n = 0, o = d;
                    while (n < o) b(t, v + o) <= s ? n = o : d = o, o = Math.floor((d - n) / 2 + n);
                    for (d = o, l = Math.max(1, v - o + 1), h = Math.min(v + o, r) + y, (_ = new Array(h + 2))[h + 1] = (1 << t) - 1, i = h; l <= i; i--)
                        if (u = x[e.charAt(i - 1)], _[i] = 0 === t ? (_[i + 1] << 1 | 1) & u : (_[i + 1] << 1 | 1) & u | (c[i + 1] | c[i]) << 1 | 1 | c[i + 1], _[i] & k && (g = b(t, i - 1)) <= s) {
                            if (s = g, a = i - 1, f.push(a), !(v < a)) break;
                            l = Math.max(1, 2 * v - a)
                        }
                    if (b(t + 1, v) > s) break;
                    c = _
                }
                return {
                    isMatch: 0 <= a,
                    score: g
                }
            }, !0 === e ? {
                search: t
            } : t(e)
        }, i.vakata.search.defaults = {
            location: 0,
            distance: 100,
            threshold: .6,
            fuzzy: !1,
            caseSensitive: !1
        }, S.jstree.defaults.sort = function (e, t) {
            return this.get_text(e) > this.get_text(t) ? 1 : -1
        };
        var p = !(S.jstree.plugins.sort = function (e, t) {
            this.bind = function () {
                t.bind.call(this), this.element.on("model.jstree", S.proxy(function (e, t) {
                    this.sort(t.parent, !0)
                }, this)).on("rename_node.jstree create_node.jstree", S.proxy(function (e, t) {
                    this.sort(t.parent || t.node.parent, !1), this.redraw_node(t.parent || t.node.parent, !0)
                }, this)).on("move_node.jstree copy_node.jstree", S.proxy(function (e, t) {
                    this.sort(t.parent, !1), this.redraw_node(t.parent, !0)
                }, this))
            }, this.sort = function (e, t) {
                var i, r;
                if ((e = this.get_node(e)) && e.children && e.children.length && (e.children.sort(S.proxy(this.settings.sort, this)), t))
                    for (i = 0, r = e.children_d.length; i < r; i++) this.sort(e.children_d[i], !1)
            }
        }),
            t, m;
        S.jstree.defaults.state = {
            key: "jstree",
            events: "changed.jstree open_node.jstree close_node.jstree check_node.jstree uncheck_node.jstree",
            ttl: !1,
            filter: !1,
            preserve_loaded: !1
        }, S.jstree.plugins.state = function (e, t) {
            this.bind = function () {
                t.bind.call(this);
                var i = S.proxy(function () {
                    this.element.on(this.settings.state.events, S.proxy(function () {
                        p && clearTimeout(p), p = setTimeout(S.proxy(function () {
                            this.save_state()
                        }, this), 100)
                    }, this)), this.trigger("state_ready")
                }, this);
                this.element.on("ready.jstree", S.proxy(function (e, t) {
                    this.element.one("restore_state.jstree", i), this.restore_state() || i()
                }, this))
            }, this.save_state = function () {
                var e = this.get_state();
                this.settings.state.preserve_loaded || delete e.core.loaded;
                var t = {
                    state: e,
                    ttl: this.settings.state.ttl,
                    sec: +new Date
                };
                S.vakata.storage.set(this.settings.state.key, JSON.stringify(t))
            }, this.restore_state = function () {
                var i = S.vakata.storage.get(this.settings.state.key);
                if (i) try {
                    i = JSON.parse(i)
                } catch (e) {
                    return !1
                }
                return !(i && i.ttl && i.sec && +new Date - i.sec > i.ttl) && (i && i.state && (i = i.state), i && S.isFunction(this.settings.state.filter) && (i = this.settings.state.filter.call(this, i)), !!i && (this.settings.state.preserve_loaded || delete i.core.loaded, this.element.one("set_state.jstree", function (e, t) {
                    t.instance.trigger("restore_state", {
                        state: S.extend(!0, {}, i)
                    })
                }), this.set_state(i), !0))
            }, this.clear_state = function () {
                return S.vakata.storage.del(this.settings.state.key)
            }
        }, (t = S).vakata.storage = {
            set: function (e, t) {
                return window.localStorage.setItem(e, t)
            },
            get: function (e) {
                return window.localStorage.getItem(e)
            },
            del: function (e) {
                return window.localStorage.removeItem(e)
            }
        }, S.jstree.defaults.types = {
            default: {}
        }, S.jstree.defaults.types[S.jstree.root] = {}, S.jstree.plugins.types = function (e, l) {
            this.init = function (e, t) {
                var i, r;
                if (t && t.types && t.types.default)
                    for (i in t.types)
                        if ("default" !== i && i !== S.jstree.root && t.types.hasOwnProperty(i))
                            for (r in t.types.default) t.types.default.hasOwnProperty(r) && t.types[i][r] === E && (t.types[i][r] = t.types.default[r]);
                l.init.call(this, e, t), this._model.data[S.jstree.root].type = S.jstree.root
            }, this.refresh = function (e, t) {
                l.refresh.call(this, e, t), this._model.data[S.jstree.root].type = S.jstree.root
            }, this.bind = function () {
                this.element.on("model.jstree", S.proxy(function (e, t) {
                    var i = this._model.data,
                        r = t.nodes,
                        s = this.settings.types,
                        a, n, o = "default",
                        d;
                    for (a = 0, n = r.length; a < n; a++) {
                        if (o = "default", i[r[a]].original && i[r[a]].original.type && s[i[r[a]].original.type] && (o = i[r[a]].original.type), i[r[a]].data && i[r[a]].data.jstree && i[r[a]].data.jstree.type && s[i[r[a]].data.jstree.type] && (o = i[r[a]].data.jstree.type), i[r[a]].type = o, !0 === i[r[a]].icon && s[o].icon !== E && (i[r[a]].icon = s[o].icon), s[o].li_attr !== E && "object" == typeof s[o].li_attr)
                            for (d in s[o].li_attr)
                                if (s[o].li_attr.hasOwnProperty(d)) {
                                    if ("id" === d) continue;
                                    i[r[a]].li_attr[d] === E ? i[r[a]].li_attr[d] = s[o].li_attr[d] : "class" === d && (i[r[a]].li_attr.class = s[o].li_attr.class + " " + i[r[a]].li_attr.class)
                                }
                        if (s[o].a_attr !== E && "object" == typeof s[o].a_attr)
                            for (d in s[o].a_attr)
                                if (s[o].a_attr.hasOwnProperty(d)) {
                                    if ("id" === d) continue;
                                    i[r[a]].a_attr[d] === E ? i[r[a]].a_attr[d] = s[o].a_attr[d] : "href" === d && "#" === i[r[a]].a_attr[d] ? i[r[a]].a_attr.href = s[o].a_attr.href : "class" === d && (i[r[a]].a_attr.class = s[o].a_attr.class + " " + i[r[a]].a_attr.class)
                                }
                    }
                    i[S.jstree.root].type = S.jstree.root
                }, this)), l.bind.call(this)
            }, this.get_json = function (e, t, i) {
                var r, s, a = this._model.data,
                    n = t ? S.extend(!0, {}, t, {
                        no_id: !1
                    }) : {},
                    o = l.get_json.call(this, e, n, i);
                if (!1 === o) return !1;
                if (S.isArray(o))
                    for (r = 0, s = o.length; r < s; r++) o[r].type = o[r].id && a[o[r].id] && a[o[r].id].type ? a[o[r].id].type : "default", t && t.no_id && (delete o[r].id, o[r].li_attr && o[r].li_attr.id && delete o[r].li_attr.id, o[r].a_attr && o[r].a_attr.id && delete o[r].a_attr.id);
                else o.type = o.id && a[o.id] && a[o.id].type ? a[o.id].type : "default", t && t.no_id && (o = this._delete_ids(o));
                return o
            }, this._delete_ids = function (e) {
                if (S.isArray(e)) {
                    for (var t = 0, i = e.length; t < i; t++) e[t] = this._delete_ids(e[t]);
                    return e
                }
                return delete e.id, e.li_attr && e.li_attr.id && delete e.li_attr.id, e.a_attr && e.a_attr.id && delete e.a_attr.id, e.children && S.isArray(e.children) && (e.children = this._delete_ids(e.children)), e
            }, this.check = function (e, t, i, r, s) {
                if (!1 === l.check.call(this, e, t, i, r, s)) return !1;
                t = t && t.id ? t : this.get_node(t), i = i && i.id ? i : this.get_node(i);
                var a = t && t.id ? s && s.origin ? s.origin : S.jstree.reference(t.id) : null,
                    n, o, d, c;
                switch (a = a && a._model && a._model.data ? a._model.data : null, e) {
                    case "create_node":
                    case "move_node":
                    case "copy_node":
                        if ("move_node" !== e || -1 === S.inArray(t.id, i.children)) {
                            if ((n = this.get_rules(i)).max_children !== E && -1 !== n.max_children && n.max_children === i.children.length) return !(this._data.core.last_error = {
                                error: "check",
                                plugin: "types",
                                id: "types_01",
                                reason: "max_children prevents function: " + e,
                                data: JSON.stringify({
                                    chk: e,
                                    pos: r,
                                    obj: !(!t || !t.id) && t.id,
                                    par: !(!i || !i.id) && i.id
                                })
                            });
                            if (n.valid_children !== E && -1 !== n.valid_children && -1 === S.inArray(t.type || "default", n.valid_children)) return !(this._data.core.last_error = {
                                error: "check",
                                plugin: "types",
                                id: "types_02",
                                reason: "valid_children prevents function: " + e,
                                data: JSON.stringify({
                                    chk: e,
                                    pos: r,
                                    obj: !(!t || !t.id) && t.id,
                                    par: !(!i || !i.id) && i.id
                                })
                            });
                            if (a && t.children_d && t.parents) {
                                for (d = o = 0, c = t.children_d.length; d < c; d++) o = Math.max(o, a[t.children_d[d]].parents.length);
                                o = o - t.parents.length + 1
                            } (o <= 0 || o === E) && (o = 1);
                            do {
                                if (n.max_depth !== E && -1 !== n.max_depth && n.max_depth < o) return !(this._data.core.last_error = {
                                    error: "check",
                                    plugin: "types",
                                    id: "types_03",
                                    reason: "max_depth prevents function: " + e,
                                    data: JSON.stringify({
                                        chk: e,
                                        pos: r,
                                        obj: !(!t || !t.id) && t.id,
                                        par: !(!i || !i.id) && i.id
                                    })
                                });
                                i = this.get_node(i.parent), n = this.get_rules(i), o++
                            } while (i)
                        }
                }
                return !0
            }, this.get_rules = function (e) {
                if (!(e = this.get_node(e))) return !1;
                var t = this.get_type(e, !0);
                return t.max_depth === E && (t.max_depth = -1), t.max_children === E && (t.max_children = -1), t.valid_children === E && (t.valid_children = -1), t
            }, this.get_type = function (e, t) {
                return !!(e = this.get_node(e)) && (t ? S.extend({
                    type: e.type
                }, this.settings.types[e.type]) : e.type)
            }, this.set_type = function (e, t) {
                var i = this._model.data,
                    r, s, a, n, o, d, c, l;
                if (S.isArray(e)) {
                    for (s = 0, a = (e = e.slice()).length; s < a; s++) this.set_type(e[s], t);
                    return !0
                }
                if (r = this.settings.types, e = this.get_node(e), !r[t] || !e) return !1;
                if ((c = this.get_node(e, !0)) && c.length && (l = c.children(".jstree-anchor")), n = e.type, o = this.get_icon(e), e.type = t, (!0 === o || !r[n] || r[n].icon !== E && o === r[n].icon) && this.set_icon(e, r[t].icon === E || r[t].icon), r[n] && r[n].li_attr !== E && "object" == typeof r[n].li_attr)
                    for (d in r[n].li_attr)
                        if (r[n].li_attr.hasOwnProperty(d)) {
                            if ("id" === d) continue;
                            "class" === d ? (i[e.id].li_attr.class = (i[e.id].li_attr.class || "").replace(r[n].li_attr[d], ""), c && c.removeClass(r[n].li_attr[d])) : i[e.id].li_attr[d] === r[n].li_attr[d] && (i[e.id].li_attr[d] = null, c && c.removeAttr(d))
                        }
                if (r[n] && r[n].a_attr !== E && "object" == typeof r[n].a_attr)
                    for (d in r[n].a_attr)
                        if (r[n].a_attr.hasOwnProperty(d)) {
                            if ("id" === d) continue;
                            "class" === d ? (i[e.id].a_attr.class = (i[e.id].a_attr.class || "").replace(r[n].a_attr[d], ""), l && l.removeClass(r[n].a_attr[d])) : i[e.id].a_attr[d] === r[n].a_attr[d] && ("href" === d ? (i[e.id].a_attr[d] = "#", l && l.attr("href", "#")) : (delete i[e.id].a_attr[d], l && l.removeAttr(d)))
                        }
                if (r[t].li_attr !== E && "object" == typeof r[t].li_attr)
                    for (d in r[t].li_attr)
                        if (r[t].li_attr.hasOwnProperty(d)) {
                            if ("id" === d) continue;
                            i[e.id].li_attr[d] === E ? (i[e.id].li_attr[d] = r[t].li_attr[d], c && ("class" === d ? c.addClass(r[t].li_attr[d]) : c.attr(d, r[t].li_attr[d]))) : "class" === d && (i[e.id].li_attr.class = r[t].li_attr[d] + " " + i[e.id].li_attr.class, c && c.addClass(r[t].li_attr[d]))
                        }
                if (r[t].a_attr !== E && "object" == typeof r[t].a_attr)
                    for (d in r[t].a_attr)
                        if (r[t].a_attr.hasOwnProperty(d)) {
                            if ("id" === d) continue;
                            i[e.id].a_attr[d] === E ? (i[e.id].a_attr[d] = r[t].a_attr[d], l && ("class" === d ? l.addClass(r[t].a_attr[d]) : l.attr(d, r[t].a_attr[d]))) : "href" === d && "#" === i[e.id].a_attr[d] ? (i[e.id].a_attr.href = r[t].a_attr.href, l && l.attr("href", r[t].a_attr.href)) : "class" === d && (i[e.id].a_attr.class = r[t].a_attr.class + " " + i[e.id].a_attr.class, l && l.addClass(r[t].a_attr[d]))
                        }
                return !0
            }
        }, S.jstree.defaults.unique = {
            case_sensitive: !1,
            trim_whitespace: !1,
            duplicate: function (e, t) {
                return e + " (" + t + ")"
            }
        }, S.jstree.plugins.unique = function (e, f) {
            this.check = function (e, t, i, r, s) {
                if (!1 === f.check.call(this, e, t, i, r, s)) return !1;
                if (t = t && t.id ? t : this.get_node(t), !(i = i && i.id ? i : this.get_node(i)) || !i.children) return !0;
                var a = "rename_node" === e ? r : t.text,
                    n = [],
                    o = this.settings.unique.case_sensitive,
                    d = this.settings.unique.trim_whitespace,
                    c = this._model.data,
                    l, h, _;
                for (l = 0, h = i.children.length; l < h; l++) _ = c[i.children[l]].text, o || (_ = _.toLowerCase()), d && (_ = _.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "")), n.push(_);
                switch (o || (a = a.toLowerCase()), d && (a = a.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "")), e) {
                    case "delete_node":
                        return !0;
                    case "rename_node":
                        return _ = t.text || "", o || (_ = _.toLowerCase()), d && (_ = _.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "")), (l = -1 === S.inArray(a, n) || t.text && _ === a) || (this._data.core.last_error = {
                            error: "check",
                            plugin: "unique",
                            id: "unique_01",
                            reason: "Child with name " + a + " already exists. Preventing: " + e,
                            data: JSON.stringify({
                                chk: e,
                                pos: r,
                                obj: !(!t || !t.id) && t.id,
                                par: !(!i || !i.id) && i.id
                            })
                        }), l;
                    case "create_node":
                        return (l = -1 === S.inArray(a, n)) || (this._data.core.last_error = {
                            error: "check",
                            plugin: "unique",
                            id: "unique_04",
                            reason: "Child with name " + a + " already exists. Preventing: " + e,
                            data: JSON.stringify({
                                chk: e,
                                pos: r,
                                obj: !(!t || !t.id) && t.id,
                                par: !(!i || !i.id) && i.id
                            })
                        }), l;
                    case "copy_node":
                        return (l = -1 === S.inArray(a, n)) || (this._data.core.last_error = {
                            error: "check",
                            plugin: "unique",
                            id: "unique_02",
                            reason: "Child with name " + a + " already exists. Preventing: " + e,
                            data: JSON.stringify({
                                chk: e,
                                pos: r,
                                obj: !(!t || !t.id) && t.id,
                                par: !(!i || !i.id) && i.id
                            })
                        }), l;
                    case "move_node":
                        return (l = t.parent === i.id && (!s || !s.is_multi) || -1 === S.inArray(a, n)) || (this._data.core.last_error = {
                            error: "check",
                            plugin: "unique",
                            id: "unique_03",
                            reason: "Child with name " + a + " already exists. Preventing: " + e,
                            data: JSON.stringify({
                                chk: e,
                                pos: r,
                                obj: !(!t || !t.id) && t.id,
                                par: !(!i || !i.id) && i.id
                            })
                        }), l
                }
                return !0
            }, this.create_node = function (e, t, i, r, s) {
                if (!t || t.text === E) {
                    if (null === e && (e = S.jstree.root), !(e = this.get_node(e))) return f.create_node.call(this, e, t, i, r, s);
                    if (!(i = i === E ? "last" : i).toString().match(/^(before|after)$/) && !s && !this.is_loaded(e)) return f.create_node.call(this, e, t, i, r, s);
                    t || (t = {});
                    var a, n, o, d, c, l = this._model.data,
                        h = this.settings.unique.case_sensitive,
                        _ = this.settings.unique.trim_whitespace,
                        u = this.settings.unique.duplicate,
                        g;
                    for (n = a = this.get_string("New node"), o = [], d = 0, c = e.children.length; d < c; d++) g = l[e.children[d]].text, h || (g = g.toLowerCase()), _ && (g = g.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "")), o.push(g);
                    d = 1, g = n, h || (g = g.toLowerCase()), _ && (g = g.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, ""));
                    while (-1 !== S.inArray(g, o)) g = n = u.call(this, a, ++d).toString(), h || (g = g.toLowerCase()), _ && (g = g.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, ""));
                    t.text = n
                }
                return f.create_node.call(this, e, t, i, r, s)
            }
        };
        var v = k.createElement("DIV");
        if (v.setAttribute("unselectable", "on"), v.setAttribute("role", "presentation"), v.className = "jstree-wholerow", v.innerHTML = "&#160;", S.jstree.plugins.wholerow = function (e, a) {
            this.bind = function () {
                a.bind.call(this), this.element.on("ready.jstree set_state.jstree", S.proxy(function () {
                    this.hide_dots()
                }, this)).on("init.jstree loading.jstree ready.jstree", S.proxy(function () {
                    this.get_container_ul().addClass("jstree-wholerow-ul")
                }, this)).on("deselect_all.jstree", S.proxy(function (e, t) {
                    this.element.find(".jstree-wholerow-clicked").removeClass("jstree-wholerow-clicked")
                }, this)).on("changed.jstree", S.proxy(function (e, t) {
                    this.element.find(".jstree-wholerow-clicked").removeClass("jstree-wholerow-clicked");
                    var i = !1,
                        r, s;
                    for (r = 0, s = t.selected.length; r < s; r++)(i = this.get_node(t.selected[r], !0)) && i.length && i.children(".jstree-wholerow").addClass("jstree-wholerow-clicked")
                }, this)).on("open_node.jstree", S.proxy(function (e, t) {
                    this.get_node(t.node, !0).find(".jstree-clicked").parent().children(".jstree-wholerow").addClass("jstree-wholerow-clicked")
                }, this)).on("hover_node.jstree dehover_node.jstree", S.proxy(function (e, t) {
                    "hover_node" === e.type && this.is_disabled(t.node) || this.get_node(t.node, !0).children(".jstree-wholerow")["hover_node" === e.type ? "addClass" : "removeClass"]("jstree-wholerow-hovered")
                }, this)).on("contextmenu.jstree", ".jstree-wholerow", S.proxy(function (e) {
                    if (this._data.contextmenu) {
                        e.preventDefault();
                        var t = S.Event("contextmenu", {
                            metaKey: e.metaKey,
                            ctrlKey: e.ctrlKey,
                            altKey: e.altKey,
                            shiftKey: e.shiftKey,
                            pageX: e.pageX,
                            pageY: e.pageY
                        });
                        S(e.currentTarget).closest(".jstree-node").children(".jstree-anchor").first().trigger(t)
                    }
                }, this)).on("click.jstree", ".jstree-wholerow", function (e) {
                    e.stopImmediatePropagation();
                    var t = S.Event("click", {
                        metaKey: e.metaKey,
                        ctrlKey: e.ctrlKey,
                        altKey: e.altKey,
                        shiftKey: e.shiftKey
                    });
                    S(e.currentTarget).closest(".jstree-node").children(".jstree-anchor").first().trigger(t).focus()
                }).on("dblclick.jstree", ".jstree-wholerow", function (e) {
                    e.stopImmediatePropagation();
                    var t = S.Event("dblclick", {
                        metaKey: e.metaKey,
                        ctrlKey: e.ctrlKey,
                        altKey: e.altKey,
                        shiftKey: e.shiftKey
                    });
                    S(e.currentTarget).closest(".jstree-node").children(".jstree-anchor").first().trigger(t).focus()
                }).on("click.jstree", ".jstree-leaf > .jstree-ocl", S.proxy(function (e) {
                    e.stopImmediatePropagation();
                    var t = S.Event("click", {
                        metaKey: e.metaKey,
                        ctrlKey: e.ctrlKey,
                        altKey: e.altKey,
                        shiftKey: e.shiftKey
                    });
                    S(e.currentTarget).closest(".jstree-node").children(".jstree-anchor").first().trigger(t).focus()
                }, this)).on("mouseover.jstree", ".jstree-wholerow, .jstree-icon", S.proxy(function (e) {
                    return e.stopImmediatePropagation(), this.is_disabled(e.currentTarget) || this.hover_node(e.currentTarget), !1
                }, this)).on("mouseleave.jstree", ".jstree-node", S.proxy(function (e) {
                    this.dehover_node(e.currentTarget)
                }, this))
            }, this.teardown = function () {
                this.settings.wholerow && this.element.find(".jstree-wholerow").remove(), a.teardown.call(this)
            }, this.redraw_node = function (e, t, i, r) {
                if (e = a.redraw_node.apply(this, arguments)) {
                    var s = v.cloneNode(!0); - 1 !== S.inArray(e.id, this._data.core.selected) && (s.className += " jstree-wholerow-clicked"), this._data.core.focused && this._data.core.focused === e.id && (s.className += " jstree-wholerow-hovered"), e.insertBefore(s, e.childNodes[0])
                }
                return e
            }
        }, window.customElements && Object && Object.create) {
            var j = Object.create(HTMLElement.prototype);
            j.createdCallback = function () {
                var e = {
                    core: {},
                    plugins: []
                },
                    t;
                for (t in S.jstree.plugins) S.jstree.plugins.hasOwnProperty(t) && this.attributes[t] && (e.plugins.push(t), this.getAttribute(t) && JSON.parse(this.getAttribute(t)) && (e[t] = JSON.parse(this.getAttribute(t))));
                for (t in S.jstree.defaults.core) S.jstree.defaults.core.hasOwnProperty(t) && this.attributes[t] && (e.core[t] = JSON.parse(this.getAttribute(t)) || this.getAttribute(t));
                S(this).jstree(e)
            };
            try {
                window.customElements.define("vakata-jstree", function () { }, {
                    prototype: j
                })
            } catch (e) { }
        }
    }
});