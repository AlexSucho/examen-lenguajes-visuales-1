package com.rogerlopez.examen_programacion_1.controller;

import com.rogerlopez.examen_programacion_1.model.Producto;
import com.rogerlopez.examen_programacion_1.model.Categoria;
import com.rogerlopez.examen_programacion_1.repository.ProductoRepository;
import com.rogerlopez.examen_programacion_1.repository.CategoriaRepository;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Controller
@RequestMapping("/productos")
public class ProductoController {

    @Autowired
    private ProductoRepository productoRepository;

    @Autowired
    private CategoriaRepository categoriaRepository;

    // Listar con paginación
    @GetMapping
    public String listarProductos(Model model,
                                  @RequestParam(defaultValue = "0") int page,
                                  @RequestParam(defaultValue = "") String filtro) {
        Page<Producto> productos;
        if (filtro.isEmpty()) {
            productos = productoRepository.findAll(PageRequest.of(page, 5));
        } else {
            productos = productoRepository.findByNombreContainingIgnoreCase(filtro, PageRequest.of(page, 5));
        }
        model.addAttribute("productos", productos);
        model.addAttribute("filtro", filtro);
        return "productos/listar";
    }

    // Formulario crear
    @GetMapping("/nuevo")
    public String mostrarFormularioNuevo(Model model) {
        model.addAttribute("producto", new Producto());
        model.addAttribute("categorias", categoriaRepository.findAll());
        return "productos/formulario";
    }

    // Guardar
    @PostMapping("/guardar")
    public String guardarProducto(@Valid @ModelAttribute Producto producto, BindingResult result, Model model) {
        if (result.hasErrors()) {
            model.addAttribute("categorias", categoriaRepository.findAll());
            return "productos/formulario";
        }
        productoRepository.save(producto);
        return "redirect:/productos";
    }

    // Editar
    @GetMapping("/editar/{id}")
    public String mostrarFormularioEditar(@PathVariable Long id, Model model) {
        Producto producto = productoRepository.findById(id).orElseThrow();
        model.addAttribute("producto", producto);
        model.addAttribute("categorias", categoriaRepository.findAll());
        return "productos/formulario";
    }

    // Eliminar
    @GetMapping("/eliminar/{id}")
    public String eliminarProducto(@PathVariable Long id) {
        productoRepository.deleteById(id);
        return "redirect:/productos";
    }
}
