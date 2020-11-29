(ns index (:require [babashka.pods :as pods]))

(pods/load-pod "bootleg")
(require '[pod.retrogradeorbit.bootleg.utils :refer [convert-to]])

(def body
  [:body [:center
          [:h1 "Hi!"]
          [:h3 "Nothing here yet, check it out later ... &#9951;"]]])

(def head
  [:head
   [:meta {:charset "utf-8"}]
   [:title "Ol&aacute!"]
   [:link {:type "image/png" :href "favicon.png" :rel "icon"}]
   [:meta {:name "viewport" :content "width=device-width, initial-scale=1"}]
   [:link#pagestyle {:rel "stylesheet" :type "text/css"}]
   [:script (slurp "random-stylesheet.js")]])

((comp #(spit "index.html" %) #(convert-to % :html))
 ["<!DOCTYPE html>" [:html head body]])

(println "done!")