public class ListadoDirectorio{
    public static void main(String[] args){
        String ruta =".";
        if(args.length>=1){
            ruta = args[0];
        }
        File fich = new File(ruta);
        if(!fich.exists()){
            System.out.println("No existe el fichero");
        }else{
            System.out.println("Existe el fichero");
        }
    }
}