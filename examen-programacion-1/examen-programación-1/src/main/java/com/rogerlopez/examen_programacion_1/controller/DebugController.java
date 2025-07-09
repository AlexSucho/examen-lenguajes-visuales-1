package com.rogerlopez.examen_programacion_1.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class DebugController {
    @GetMapping("/publico")
    public String publico() {
        return "publico";
    }
}

