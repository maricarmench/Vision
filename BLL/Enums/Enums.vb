Imports Studio.Net.BLL

Public Enum RecetaComunOperacion
    Venta = 1
    Presupuesto = 2
End Enum

Public Enum RecetaEstado
    Ingresada
    <PropertyDescriptionAttribute("Enviada a taller")> _
    EnviadaTaller
    <PropertyDescriptionAttribute("Para entregar")> _
    AEntregar
    <PropertyDescriptionAttribute("Entregada")> _
    Entregada
End Enum

Public Enum CristalClasificacion
    <PropertyDescriptionAttribute("De máquina")> _
    Maquina
    <PropertyDescriptionAttribute("Terminado")> _
    Terminado
End Enum

Public Enum RecetaVentaTipo
    Contado = 1
    Credito = 2
End Enum

Public Enum ManejoCilindricos
    Indistinto
    <PropertyDescriptionAttribute("Solo negativos")> _
    SoloNegativo
    <PropertyDescriptionAttribute("Solo positivos")> _
    SoloPositivo
End Enum